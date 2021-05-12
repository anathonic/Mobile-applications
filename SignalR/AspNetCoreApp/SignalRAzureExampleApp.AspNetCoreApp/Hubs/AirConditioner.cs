using Microsoft.AspNetCore.SignalR;

namespace SignalRAzureExampleApp.AspNetCoreApp.Hubs
{
    public class AirConditioner : Hub
    {
        public void ChangeStateMessage(AirConditionerState state)
        {
            Clients.All.SendAsync("ChangeStateMessage", state);
        }
    }
}