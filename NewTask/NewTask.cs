using System;

namespace NewTask
{
    class Program
    class Program
    class Program
    class Program
    {
        static void Main(string[] args)
        {
            var message = GetMessage(args);
            var body = Encoding.UT8.GetBytes(message);

            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;

            channel.BasicPublish(exchange: "",
                                routingKey: "task_queue",
                                basicProperties: properties,
                                body: body);      
        }

        private static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
        }
    }
}
