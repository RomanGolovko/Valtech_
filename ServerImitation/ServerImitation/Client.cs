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
            var filePath = @"D:\GitHub Repository\Valtech_\ServerImitation\HTMLs\" + requestUri;

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

            while (fs.Position < fs.Length)
            {
                count = fs.Read(buffer, 0, buffer.Length);
                client.GetStream().Write(buffer, 0, count);
            }

            fs.Close();
            client.Close();
        }
    }
}
