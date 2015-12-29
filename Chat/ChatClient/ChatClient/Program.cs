using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;

namespace ChatClient
{
    class Program
    {
        private static string _userName;
        private const string Host = "127.0.0.1";
        private const int Port = 8888;
        private static TcpClient _client;
        private static NetworkStream _stream;

        private static void Main(string[] args)
        {
            Console.Write("Введите свое имя: ");
            _userName = Console.ReadLine();
            _client = new TcpClient();
            try
            {
                _client.Connect(Host, Port);
                _stream = _client.GetStream();

                var message = _userName;

                if (message != null)
                {
                    var data = Encoding.Unicode.GetBytes(message);
                    _stream.Write(data, 0, data.Length);
                }

                var receiveThread = new Thread(ReceiveMessage);
                receiveThread.Start();
                Console.WriteLine($"Добро пожаловать, {_userName}");
                SendMessage();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }

        private static void SendMessage()
        {
            Console.WriteLine("Введите сообщение: ");

            while (true)
            {
                var message = Console.ReadLine();

                if (message == null) continue;
                var data = Encoding.Unicode.GetBytes(message);
                _stream.Write(data, 0, data.Length);


                if (message == "exit")
                {
                    Disconnect();
                }
            }
        }

        private static void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    var data = new byte[64];
                    var builder = new StringBuilder();
                    do
                    {
                        var bytes = _stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    } while (_stream.DataAvailable);

                    var message = builder.ToString();
                    Console.WriteLine(message);
                }
                catch
                {
                    Console.WriteLine("Подключение прервано!");
                    Console.ReadLine();
                    Disconnect();
                }
            }
        }

        private static void Disconnect()
        {
            _stream?.Close();
            _client?.Close();
            Environment.Exit(0);
        }
    }
}