namespace UpdateQ.Simulator.Core.Interfaces
{
    using System;

    public interface ITaskManager
    {
        void StartSendindSensorData(Guid sensorId, TimeSpan timeout);
        void StopSendindSensorData(Guid sensorId);
        void StopSendindAllSensorData();
    }
}
