namespace UpdateQ.Simulator.Core
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using UpdateQ.Simulator.Core.Interfaces;

    public class RequestManager : IRequestManager
    {
        private HttpClient client;
        // private Dictionary<Guid, CancelationTokenSource> // Cancel a running task through cancelation token
        // private ICollection<Task> tasks;

        public RequestManager()
        {
            this.client = new HttpClient();
            //this.tasks = new HashSet<Task>();
        }

        public void StartSendindSensorData()
        {

        }


    }
}
