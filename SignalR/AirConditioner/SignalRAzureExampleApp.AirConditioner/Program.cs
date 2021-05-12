using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace SignalRAzureExampleApp.AirConditioner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration configuration = builder.Build();

            var client = new SignalRClient(configuration);
            client.Start();

            Console.WriteLine("To exit app press any key");
            Console.ReadKey();
            client.StopAsync();
        }
    }
}