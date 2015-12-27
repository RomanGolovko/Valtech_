using System.Net;
using System.Net.Sockets;
using ServerImitation;

namespace HTTPServer
{
    class Server
    {
        private readonly TcpListener _listener;

        public Server(int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
            _listener.Start();

            while (true)
            {
                new Client(_listener.AcceptTcpClient());
            }
        }

        ~Server()
        {
            _listener?.Stop();
        }
    }
}
