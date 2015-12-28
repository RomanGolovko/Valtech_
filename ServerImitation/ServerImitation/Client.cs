using System;
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
            else if (requestUri.Contains(@"/Job"))
            {
                var temp = requestUri.Split('&');
                var num1 = int.Parse(temp[1]);
                var num2 = int.Parse(temp[2]);
                var action = temp[3];
                string Str = "HTTP/1.1 200 OK\nContent-type: text/html\nContent-Length:" + LocalWork(num1, num2, action).ToString().Length.ToString() + "\n\n" + LocalWork(num1, num2, action);
                var Buffer = Encoding.ASCII.GetBytes(Str);
                client.GetStream().Write(Buffer, 0, Buffer.Length);
            }

            client.Close();
        }

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

            var header = "HTTP/1.1 200 OK\nContent-type: text/html\nContent-Length:" + fs.Length + "\n\n";
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
    }
}
