namespace UpdateQ.Simulator.Core.Managers
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using UpdateQ.Simulator.Core.Interfaces;
    using UpdateQ.Simulator.Model;
    using UpdateQ.Simulator.Utils;

    public class SensorManager : ISensorManager
    {
        private string resultMsg;
        private ICollection<SensorMapInfo> sensors;
        private readonly ITaskManager taskManager;

        public SensorManager(ITaskManager taskManager)
        {
            this.taskManager = taskManager;
            this.sensors = new HashSet<SensorMapInfo>();
        }

        public IEnumerable<SensorMapInfo> Sensors => this.sensors;

        public async Task<string> RegisterSensors()
        {
            using (StreamReader sr = new StreamReader(Constants.APPSETTING_FULL_PATH))
            {
                string file = await sr.ReadToEndAsync();
                this.sensors = JsonConvert.DeserializeObject<ContainerSensorsModel>(file).Sensors;
            }

            return Operations.SuccessfullyInitAllSensors;
        }

        public string AddSensorInputData(IList<string> arguments)
        {
            Guid sensorId = Guid.Parse(arguments[0]);
            int startRange = int.Parse(arguments[1]);
            int endRange = int.Parse(arguments[2]);
            TimeSpan interval = TimeSpan.FromSeconds(double.Parse(arguments[3]));

            SensorMapInfo sensor = this.sensors.FirstOrDefault(s => s.SensorId == sensorId);

            if (sensor == null)
            {
                SensorMapInfo newSensor = new SensorMapInfo(sensorId, startRange, endRange, interval);

                this.sensors.Add(newSensor);

                this.resultMsg = Operations.SuccessfullyAddedSensor(sensorId);
            }
            else
            {
                sensor.StartRange = startRange;
                sensor.EndRange = endRange;
                sensor.Interval = interval;

                this.resultMsg = Operations.SuccessfullyChangedSensorData(sensorId);
            }

            return this.resultMsg;
        }

        public string Start(string sensorIdStr)
        {
            Guid sensorId = Guid.Parse(sensorIdStr);

            SensorMapInfo sensor = this.sensors.FirstOrDefault(s => s.SensorId == sensorId);

            if (sensor == null)
            {
                this.resultMsg = Operations.SensorNotRegistered(sensorId);
            }
            else if (sensor.IsActive)
            {
                this.resultMsg = Operations.SensorIsActive(sensorId);
            }
            else
            {
                this.taskManager.StartSendindSensorData(sensor);

                sensor.IsActive = true;

                this.resultMsg = Operations.StartedSendingSensorData(sensorId);
            }

            return this.resultMsg;
        }

        public string Stop(string sensorIdStr)
        {
            Guid sensorId = Guid.Parse(sensorIdStr);

            SensorMapInfo sensor = this.sensors.FirstOrDefault(s => s.SensorId == sensorId);

            if (sensor == null)
            {
                this.resultMsg = Operations.SensorNotRegistered(sensorId);
            }
            else if (!sensor.IsActive)
            {
                this.resultMsg = Operations.SensorIsNotActive(sensorId);
            }
            else
            {
                this.taskManager.StopSendindSensorData(sensorId);

                sensor.IsActive = false;

                this.resultMsg = Operations.StoppedSendingSensorData(sensorId);
            }

            return this.resultMsg;
        }

        public string Shutdown()
        {
            this.taskManager.StopSendindAllSensorData();

            return Operations.AllSystemsShutdown();
        }

        public string ChangeGeneratorSensor(string methodTypeStr, string sensorIdStr)
        {
            Guid sensorId = Guid.Parse(sensorIdStr);

            SensorMapInfo sensor = this.sensors.FirstOrDefault(s => s.SensorId == sensorId);

            if (sensor == null)
            {
                this.resultMsg = Operations.SensorNotRegistered(sensorId);
            }
            else
            {
                try
                {
                    var methodType = (GenMethodTypeEnum) Enum.Parse(typeof(GenMethodTypeEnum), methodTypeStr);

                    sensor.TypeGenerator = methodType;

                    this.resultMsg = Operations.SuccessfullyChangedGenerator(sensorId, methodType);
                }
                catch (ArgumentException)
                {
                    this.resultMsg = Operations.InvalidMethodGenerator(methodTypeStr);
                }
            }

            return this.resultMsg;
        }

        public string ChangeGeneratorAllSensors(string methodTypeStr)
        {
            try
            {
                var methodType = (GenMethodTypeEnum) Enum.Parse(typeof(GenMethodTypeEnum), methodTypeStr);

                foreach (var sensor in this.sensors)
                {
                    sensor.TypeGenerator = methodType;
                }

                this.resultMsg = Operations.SuccessfullyChangedGeneratorAllSensors(methodType);
            }
            catch (ArgumentException)
            {
                this.resultMsg = Operations.InvalidMethodGenerator(methodTypeStr);
            }

            return this.resultMsg;
        }
    }
}
