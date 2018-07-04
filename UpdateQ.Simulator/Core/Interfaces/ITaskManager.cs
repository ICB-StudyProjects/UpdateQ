namespace UpdateQ.Simulator.Core.Interfaces
{
    using System;
    using System.Net.Http;
    using UpdateQ.Simulator.Model;

    public interface ITaskManager
    {
        void StartSendindSensorData(SensorMapInfo sensor);
        void StopSendindSensorData(Guid sensorId);
        void StopSendindAllSensorData();
    }
}
