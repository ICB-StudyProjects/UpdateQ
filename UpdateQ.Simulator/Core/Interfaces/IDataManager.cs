namespace UpdateQ.Simulator.Core.Interfaces
{
    using System;
    using UpdateQ.Simulator.Model;

    public interface IDataManager
    {
        SensorDto GenerateSensorData(Guid sensorId);
    }
}
