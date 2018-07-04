namespace UpdateQ.Simulator.Core.Interfaces
{
    using UpdateQ.Simulator.Model;

    public interface IRequestManager
    {
        void StartSendindSensorData(SensorMapInfo sensor);
    }
}
