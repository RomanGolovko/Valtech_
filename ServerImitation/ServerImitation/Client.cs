using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace ServerImitation
{
    class Client
    {
        public Client(TcpClient client)
        {
            var request = "";
            var buffer = new byte[1024];
            int count;

            while ((count = client.GetStream().Read(buffer, 0, buffer.Length)) > 0)
            {
                request += Encoding.ASCII.GetString(buffer, 0, count);

                if (request.IndexOf("\r\n\r\n", StringComparison.Ordinal) > 0 || request.Length > 4096)
                {
                    break;
                }
            }


            var requestMatch = Regex.Match(request, @"^\w+\s+([^\s\?]+)[^\s]*\s+HTTP/.*|");
            var requestUri = requestMatch.Groups[1].Value;

            if (requestUri == @"/Index.html" || requestUri == @"/About.html" || requestUri == @"/Contacts.html")
            {
                ReturnStaticPage(client, requestUri);
            }
            else if (requestUri.Contains(@".php"))
            {
                var parse = request.Split('/');
                var query = parse[1].Split(' ');
                var data = query[0].Split('?');
                ReturnPhpData(client, data[1]);
            }
            else if (requestUri.Contains(@"/Job"))
            {
                ReturnServiceData(client, requestUri);
            }

            client.Close();
        }

        #region Return page
        public void ReturnStaticPage(TcpClient client, string requestUri)
        {
            var filePath = @"C:\Users\Roman\Documents\Repository\Valtech_\ServerImitation\HTMLs\" + requestUri;
            //var filePath = @"D:\GitHub Repository\Valtech_\ServerImitation\HTMLs\" + requestUri;

            FileStream fs;

            try
            {
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            catch (Exception) 
            {
                return;
            }

            var header = "HTTP/1.1 200 OK\nContent-type: text/html\nAccess-Control-Allow-Origin: *\nContent-Length:" + fs.Length + "\n\n";
            var headersBuffer = Encoding.ASCII.GetBytes(header);
            client.GetStream().Write(headersBuffer, 0, headersBuffer.Length);

            int count;
            var buffer = new byte[1024];

            while (fs.Position < fs.Length)
            {
                count = fs.Read(buffer, 0, buffer.Length);
                client.GetStream().Write(buffer, 0, count);
            }

            fs.Close();
        }
        #endregion

        #region Return PHP data
        public void ReturnPhpData(TcpClient client, string query)
        {
            var php = new Process();
            php.StartInfo.FileName = @"C:\xampp\php\php-cgi.exe";
            php.StartInfo.UseShellExecute = false;
            php.StartInfo.RedirectStandardOutput = true;
            php.OutputDataReceived += new DataReceivedEventHandler(php_OutputDataReceived);
            php.StartInfo.EnvironmentVariables.Add("SCRIPT_FILENAME", @"C:\Users\Roman\Documents\Repository\Valtech_\ServerImitation\PHP\Calculator.php");
            php.StartInfo.EnvironmentVariables.Add("QUERY_STRING", query);
            php.Start();
            var output = php.StandardOutput.ReadToEnd();
            php.WaitForExit();
            php.Close();

            string Str = "HTTP/1.1 200 OK" + output;
            var Buffer = Encoding.ASCII.GetBytes(Str);
            client.GetStream().Write(Buffer, 0, Buffer.Length);
        }

        static void php_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }
        #endregion

        #region Return Service data
        public void ReturnServiceData(TcpClient client, string requestUri)
        {
            var temp = requestUri.Split('&');
            var num1 = int.Parse(temp[1]);
            var num2 = int.Parse(temp[2]);
            var action = temp[3];
            var data = LocalWork(num1, num2, action);
            string Str = "HTTP/1.1 200 OK\nContent-type: text/html\nAccess-Control-Allow-Origin: *\nContent-Length:" + data.ToString().Length.ToString() + "\n\n" + data;
            var Buffer = Encoding.ASCII.GetBytes(Str);
            client.GetStream().Write(Buffer, 0, Buffer.Length);
        }

        public int LocalWork(int num1, int num2, string action)
        {
            var result = 0;

            switch (action)
            {
                case "Add": result = num1 + num2; break;
                case "Sub": result = num1 - num2; break;
                case "Mul": result = num1 * num2; break;
                case "Div":
                    {
                        if (num2 == 0)
                        {
                            throw new DivideByZeroException();
                        }
                        result = num1 / num2;
                    }
                    break;
                default:
                    break;
            }

            return result;
        }
        #endregion
    }
}
