namespace UpdateQ.Hub.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using System.Threading;
    using UpdateQ.Hub.Hubs;
    using UpdateQ.Simulator.Model;

    [ApiController]
    public class SensorController : Controller
    {
        private readonly IHubContext<SensorHub> sensorHubContext;

        public SensorController(IHubContext<SensorHub> sensorHubContext)
        {
            this.sensorHubContext = sensorHubContext;
        }

        [HttpPost]
        [Route("api/sensors")]
        public IActionResult Post([FromBody] SensorDto sensor, CancellationToken cToken)
        {
            if (cToken.IsCancellationRequested)
            {
                return BadRequest();
            }

            this.sensorHubContext.Clients.All.SendAsync("ReceiveSensorData",
                $"Sensor: {sensor.SensorId.ToString()}; Sends: {sensor.CurrentData} data package");

            return Ok();
        }
    }
}
