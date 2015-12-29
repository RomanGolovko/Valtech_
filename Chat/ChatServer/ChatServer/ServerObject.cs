using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

namespace ChatServer
{
    public class ServerObject
    {
        private static TcpListener _tcpListener;
        private readonly List<ClientObject> _clients = new List<ClientObject>();

        protected internal void AddConnection(object clientObject)
        {
            var tempClientObject = clientObject as ClientObject;
           _clients.Add(tempClientObject);
        }

        protected internal void RemoveConnection(string id)
        {
            var client = _clients.FirstOrDefault(c => c.Id == id);
            if (client != null)
            {
                _clients.Remove(client);
            }
        }

        protected internal void Listen()
        {
            try
            {
                _tcpListener = new TcpListener(IPAddress.Any, 8888);
                _tcpListener.Start();
                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                while (true)
                {
                    var tcpClient = _tcpListener.AcceptTcpClient();

                    var clientObject = new ClientObject(tcpClient, this);
                    var clientThread = new Thread(clientObject.Process);
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Disconnect();
            }
        }

        protected internal void BroadcastMessage(string message, string id)
        {
            var data = Encoding.Unicode.GetBytes(message);
            foreach (var t in _clients.Where(t => t.Id != id))
            {
                t.Stream.Write(data, 0, data.Length);
            }
        }

        protected internal void Disconnect()
        {
            _tcpListener.Stop();

            foreach (var t in _clients)
            {
                t.Close();
            }
            Environment.Exit(0);
        }
    }
}