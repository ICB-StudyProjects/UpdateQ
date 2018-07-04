namespace UpdateQ.Simulator.Core.Managers
{
    using System;
    using System.Net.Http;
    using UpdateQ.Simulator.Core.Interfaces;
    using UpdateQ.Simulator.Model;

    public class RequestManager : IRequestManager
    {
        private readonly HttpClient client;
        //private readonly ITaskManager taskManager;

        public RequestManager(/*ITaskManager taskManager*/)
        {
            this.client = new HttpClient();
            //this.taskManager = taskManager;
        }

        public HttpClient CreateSensorHttpRequest(SensorMapInfo sensor)
        {
            // var randomDataToSend = GetRandomSensorData(sensor.StartRange, sensor.EndRange, sensor.TypeGenerator);

            // TODO: Create and return http request (Task)
            throw new NotImplementedException();
        }

        private void SetHeaders()
        {
            // TODO: Add http request headers
            throw new NotImplementedException();
        }

        private int GetRandomSensorData(int startRange, int endRange/*, GenMethodTypeEnum typeGenerator*/)
        {
            // Generate random integer data in 3 ways
            // Maybe put it in Utils as "RandomGenerator"?
            throw new NotImplementedException();
        }
    }
}
