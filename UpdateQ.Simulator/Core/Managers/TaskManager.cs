namespace UpdateQ.Simulator.Core.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using UpdateQ.Simulator.Core.Interfaces;

    public class TaskManager : ITaskManager
    {
        private readonly IRequestManager requestManager;
        private readonly IDictionary<Guid, CancellationTokenSource> cTokenDict;

        public TaskManager(IRequestManager requestManager)
        {
            this.requestManager = requestManager;
            this.cTokenDict = new Dictionary<Guid, CancellationTokenSource>();
        }

        public void StartSendindSensorData(Guid sensorId, TimeSpan timeout)
        {
            // Create CancellationTokenSource
            var cTokenSource = new CancellationTokenSource();

            var cToken = cTokenSource.Token;

            cToken.Register(() => CancelNotification(sensorId));

            try
            {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                this.SetTaskInterval(sensorId, timeout, cToken);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                        Console.WriteLine("Unable to compute mean: {0}",
                                          ((TaskCanceledException)e).Message);
                    else
                        Console.WriteLine("Exception: " + e.GetType().Name);
                }
            }
            finally
            {
                cTokenSource.Dispose();
            }
            
            // Add the KVP to track the token
            this.cTokenDict.Add(sensorId, cTokenSource);
        }

        public void StopSendindSensorData(Guid sensorId)
        {
            var cToken = this.cTokenDict[sensorId];

            cToken.Cancel();
            cToken.Dispose();

            this.cTokenDict.Remove(sensorId);
        }

        public void StopSendindAllSensorData()
        {
            // TODO: Add all cTokens to collection and cancel them simultaneously then clear the dict
            // this.cTokenDict.Clear();
            throw new NotImplementedException();
        }

        private async Task SetTaskInterval(Guid sensorId, TimeSpan timeout, CancellationToken cToken)
        {
            if (cToken.IsCancellationRequested)
            {
                return;
            }

            // returning the Main Thread moving it to the ThreadPool
            await Task.Delay(timeout).ConfigureAwait(false);

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            // Send http request with Cancellation Token
            this.requestManager.SendSensorHttpRequest(sensorId, cToken);

            // Recursion!!!
            this.SetTaskInterval(sensorId, timeout, cToken);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        private static void CancelNotification(Guid sensorId)
        {
            // TODO: Remove this method if the main operation stays in the sensorManager
            Console.WriteLine($"The request task for sensor {sensorId} was canceled");
        }
    }
}
