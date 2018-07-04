namespace UpdateQ.Simulator.Core
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using UpdateQ.Simulator.Core.Interfaces;
    using UpdateQ.Simulator.Model;
    using UpdateQ.Simulator.Utils;

    public class SensorManager : ISensorManager
    {
        private string resultMsg;
        private ICollection<SensorMapInfo> sensorsData;
        private readonly IRequestManager requestManager;

        public SensorManager(IRequestManager requestManager)
        {
            this.requestManager = requestManager;
            this.sensorsData = new HashSet<SensorMapInfo>();
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
            else
            {
                this.requestManager.StartSendindSensorData(sensor);

                this.resultMsg = Operations.StartSendingSensorData(sensorId);
            }

            //var cts = new CancellationTokenSource();
            //Task.Factory.StartNew(() => Task.Delay(1000, cts.Token));
            //cts.Cancel();


            return this.resultMsg;
        }

        public string Stop(string sensorId)
        {
            // TODO: Stop sending data for sensor through http requester (class)
            throw new NotImplementedException();
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
    }
}
