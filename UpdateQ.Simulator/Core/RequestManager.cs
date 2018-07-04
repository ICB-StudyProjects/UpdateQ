namespace UpdateQ.Simulator.Core
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using UpdateQ.Simulator.Core.Interfaces;
    using UpdateQ.Simulator.Model;

    public class RequestManager : IRequestManager
    {
        private readonly HttpClient client;
        // Cancel a running task through cancelation token
        private readonly IDictionary<Guid, CancellationTokenSource> tokenDict;

        public RequestManager()
        {
            this.client = new HttpClient();
            this.tokenDict = new Dictionary<Guid, CancellationTokenSource>();
        }

        public void StartSendindSensorData(SensorMapInfo sensor)
        {
            // TODO: Start sending data for sensor through http requester (class)
        }


    }
}
