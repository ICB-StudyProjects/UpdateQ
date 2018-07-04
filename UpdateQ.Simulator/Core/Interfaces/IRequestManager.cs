namespace UpdateQ.Simulator.Core.Interfaces
{
    using System.Net.Http;
    using UpdateQ.Simulator.Model;

    public interface IRequestManager
    {
        HttpClient CreateSensorHttpRequest(SensorMapInfo sensor);
    }
}
