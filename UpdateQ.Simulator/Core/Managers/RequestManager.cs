namespace UpdateQ.Simulator.Core.Managers
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using UpdateQ.Simulator.Core.Interfaces;
    using UpdateQ.Simulator.Model;

    public class RequestManager : IRequestManager
    {
        private readonly HttpClient client;
        private IDataManager dataManager;

        public RequestManager(IDataManager dataManager)
        {
            this.dataManager = dataManager;
            this.client = new HttpClient();

            this.SetHeaders();
        }

        public async void SendSensorHttpRequest(Guid sensorId, CancellationToken cToken)
        {
            SensorDto sensorData = this.dataManager.GenerateSensorData(sensorId);

            await this.client.PostAsJsonAsync("api/sensors", sensorData, cToken)
                .ContinueWith(t => TaskContinuationOptions.NotOnCanceled);

            if (!cToken.IsCancellationRequested)
            {
                Console.WriteLine($"Data - {sensorData.CurrentData} - was send from sensor {sensorId}");
            }

            return;
        }

        private void SetHeaders()
        {
            // TODO: Test with the API port then change it to the Hub's port
            this.client.BaseAddress = new Uri("http://localhost:40004/");
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
