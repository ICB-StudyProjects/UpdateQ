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
        private ICollection<SensorMapInfo> sensorsData;
        private readonly ITaskManager taskManager;
        private Random randomGen;

        public SensorManager(ITaskManager taskManager)
        {
            this.taskManager = taskManager;
            this.sensorsData = new HashSet<SensorMapInfo>();
            this.randomGen = new Random();
        }

        public async Task<string> RegisterSensors()
        {
            using (StreamReader sr = new StreamReader(Constants.APPSETTING_FULL_PATH))
            {
                string file = await sr.ReadToEndAsync();
                this.sensorsData = JsonConvert.DeserializeObject<ContainerSensorsModel>(file).Sensors;
            }

            return Operations.SuccessfullyInitAllSensors;
        }

        public string AddSensorInputData(IList<string> arguments)
        {
            Guid sensorId = Guid.Parse(arguments[1]);
            int startRange = int.Parse(arguments[2]);
            int endRange = int.Parse(arguments[3]);
            TimeSpan interval = TimeSpan.FromSeconds(double.Parse(arguments[4]));

            SensorMapInfo sensor = this.sensorsData.FirstOrDefault(s => s.SensorId == sensorId);

            if (sensor == null)
            {
                this.resultMsg = Operations.SensorNotRegistered(sensorId);
            }
            else
            {
                sensor = new SensorMapInfo(sensorId, startRange, endRange, interval);

                this.resultMsg = Operations.SuccessfullyChangedSensorData(sensorId);
            }

            return this.resultMsg;
        }

        public string Start(string sensorIdStr)
        {
            Guid sensorId = Guid.Parse(sensorIdStr);

            SensorMapInfo sensor = this.sensorsData.FirstOrDefault(s => s.SensorId == sensorId);

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
                this.taskManager.StartSendindSensorData(sensor.SensorId, sensor.Interval);

                sensor.IsActive = true;

                this.resultMsg = Operations.StartedSendingSensorData(sensorId);
            }

            return this.resultMsg;
        }

        public string Stop(string sensorIdStr)
        {
            Guid sensorId = Guid.Parse(sensorIdStr);

            SensorMapInfo sensor = this.sensorsData.FirstOrDefault(s => s.SensorId == sensorId);

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
            // TODO: Stop sending data to ALL sensors through http requester (class)
            throw new NotImplementedException();
        }

        public string ChangeGeneratorSensor(string methodTypeStr, string sensorIdStr)
        {
            Guid sensorId = Guid.Parse(sensorIdStr);

            SensorMapInfo sensor = this.sensorsData.FirstOrDefault(s => s.SensorId == sensorId);

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

                foreach (var sensor in this.sensorsData)
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

        public SensorDto GetSensorData(Guid sensorId)
        {
            SensorMapInfo sensor = this.sensorsData.FirstOrDefault(s => s.SensorId == sensorId);

            var randomSensorData = CreateRandomSensorData(sensor.StartRange, sensor.EndRange, sensor.TypeGenerator);

            SensorDto sensorDataObg = new SensorDto
            {
                SensorId = sensor.SensorId,
                CurrentData = randomSensorData
            };

            return sensorDataObg;
        }

        private int CreateRandomSensorData(int startRange, int endRange, GenMethodTypeEnum typeGenerator)
        {
            int randomSensorData = 0;

            switch (typeGenerator)
            {
                case GenMethodTypeEnum.Random:
                    randomSensorData = randomGen.Next(startRange, endRange);
                    break;
                case GenMethodTypeEnum.Sin:
                    // Sin
                    break;
                case GenMethodTypeEnum.Cos:
                    // Random
                    break;
            }

            return randomSensorData;
        }
    }
}
