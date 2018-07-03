namespace UpdateQ.Simulator.Core.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISensorManager
    {
        Task<string> RegisterSensors();
        string AddSensorInputData(IList<string> arguments);
        string Start(string sensorIdStr);
        string Stop(string sensorIdStr);
        string ChangeGeneratorSensor(string methodTypeStr, string sensorIdStr);
        string ChangeGeneratorAllSensors(string methodTypeStr);
        string Shutdown();
    }
}
