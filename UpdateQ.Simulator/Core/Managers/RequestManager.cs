namespace UpdateQ.Simulator.Core.Managers
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using UpdateQ.Simulator.Core.Interfaces;
    using UpdateQ.Simulator.Model;

    public class RequestManager : IRequestManager
    {
        private readonly HttpClient client;
        private readonly ISensorManager sensorManager;

        public RequestManager(ISensorManager sensorManager)
        {
            this.sensorManager = sensorManager;
            this.client = new HttpClient();

            this.SetHeaders();
        }

        public void SendSensorHttpRequest(Guid sensorId, CancellationToken cToken)
        {
            SensorDto sensorData = this.sensorManager.GetSensorData(sensorId);

            //var jsonStrData = JsonConvert.SerializeObject(sensorData);
            ////var jsonData = JObject.FromObject(product);

            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "api/values");
            //request.Content = new StringContent(jsonStrData, Encoding.UTF8, "application/json");

            //this.client.SendAsync(request);

            // Sending Post HTTP Request with CancellationTokens
            this.client.PostAsJsonAsync("api/products", sensorData, cToken);
        }

        private void SetHeaders()
        {
            this.client.BaseAddress = new Uri("http://localhost:64195/");
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
