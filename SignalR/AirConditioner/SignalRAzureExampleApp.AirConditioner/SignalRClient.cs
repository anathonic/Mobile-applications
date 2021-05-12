using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using System;

namespace SignalRAzureExampleApp.AirConditioner
{
    public class SignalRClient
    {
        private readonly IConfiguration configuration;
        private HubConnection connection;

        public SignalRClient(IConfiguration configuration)
        {
            connection = new HubConnectionBuilder()
                .WithUrl(configuration["HubUrl"]).Build();
            this.configuration = configuration;
        }

        public void Start()
        {
            connection.StartAsync();
            connection.On<int>("ChangeStateMessage", (status) =>
            {
                string st = status == 1 ? "on" : "off";
                Console.WriteLine($"Air conditioner is {st}");
            });
        }

        public void StopAsync()
        {
            connection.StopAsync().GetAwaiter().GetResult();
        }
    }
}