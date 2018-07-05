namespace UpdateQ.Simulator.Core.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using UpdateQ.Simulator.Core.Interfaces;
    using UpdateQ.Simulator.Model;

    public class TaskManager : ITaskManager
    {
        private readonly IRequestManager requestManager;
        private readonly IDictionary<Guid, CancellationTokenSource> cTokenDict;

        public TaskManager(IRequestManager requestManager)
        {
            this.requestManager = requestManager;
            this.cTokenDict = new Dictionary<Guid, CancellationTokenSource>();
        }

        public async void StartSendindSensorData(SensorMapInfo sensor)
        {
            var cTokenSource = new CancellationTokenSource();

            var cToken = cTokenSource.Token;

            cToken.Register(() => CancelNotification(sensor.SensorId));

            // Add the KVP to track the token
            this.cTokenDict.Add(sensor.SensorId, cTokenSource);

            try
            {
                await this.SetTaskInterval(sensor, cToken);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine($"Your submission was canceled");
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
        }

        public void StopSendindSensorData(Guid sensorId)
        {
            var cTokenSource = this.cTokenDict[sensorId];

            this.CancelAndRemoveToken(cTokenSource);

            this.cTokenDict.Remove(sensorId);
        }

        public void StopSendindAllSensorData()
        {
            foreach (var kvp in this.cTokenDict)
            {
                var cTokenSource = kvp.Value;

                this.CancelAndRemoveToken(cTokenSource);
            }

            this.cTokenDict.Clear();
        }

        private async Task SetTaskInterval(SensorMapInfo sensor, CancellationToken cToken)
        {
            if (cToken.IsCancellationRequested)
            {
                cToken.ThrowIfCancellationRequested();
            }

            // returning the Main Thread moving it to the ThreadPool
            await Task.Delay(sensor.Interval).ConfigureAwait(false);

            // Send http request with Cancellation Token
            this.requestManager.SendSensorHttpRequest(sensor.SensorId, cToken);

            // Recursion!!!
            await this.SetTaskInterval(sensor, cToken);
        }

        private void CancelAndRemoveToken(CancellationTokenSource cTokenSource)
        {
            cTokenSource.Cancel();
            cTokenSource.Dispose();
        }

        private static void CancelNotification(Guid sensorId)
        {
            Console.WriteLine($"Cancelling your requests to sensor {sensorId}");
        }
    }
}
