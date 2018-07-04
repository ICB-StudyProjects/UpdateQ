namespace UpdateQ.Simulator.Core.Interfaces
{
    using System;
    using System.Threading;

    public interface IRequestManager
    {
        void SendSensorHttpRequest(Guid sensorId, CancellationToken cToken);
    }
}
