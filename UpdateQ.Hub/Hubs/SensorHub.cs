namespace UpdateQ.Hub.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using System.Threading.Tasks;
    using UpdateQ.Simulator.Model;

    public class SensorHub : Hub
    {
        public async Task SendSensorData(SensorDto sensorDto)
        {
            await Clients.All.SendAsync("ReceiveSensorData", sensorDto);

            // Send to a single user w/ multiple connections 
            //await Clients.User(userId).SendAsync("ReceiveSesorData", sensorDto);
        }
    }
}
