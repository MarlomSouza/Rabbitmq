using System;
using System.Text;
using RabbitMQ.Client;

namespace Send
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = AmqpTcpEndpoint.UseDefaultPort
            };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", false, false, false, null);

                    var message = "Hello World Marlom!";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(String.Empty, "hello", null, body);
                    Console.WriteLine(" [x] Sent {0}", message);
                }
            }
            Console.ReadLine();
        }
    }
}
