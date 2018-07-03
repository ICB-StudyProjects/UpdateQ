namespace UpdateQ.Simulator.Core.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISensorManager
    {
        Task<string> RegisterSensors();
        string AddSensorInputData(IList<string> arguments);
        string Start(string sensorId);
        string Stop(string sensorId);
        string ChangeGeneratorSensor(string methodTypeStr, string sensorId);
        string ChangeGeneratorAllSensors(string methodTypeStr);
        string Shutdown();
    }
}
