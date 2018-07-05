namespace UpdateQ.Simulator.Core.Managers
{
    using System;
    using System.Linq;
    using UpdateQ.Simulator.Core.Interfaces;
    using UpdateQ.Simulator.Model;
    using UpdateQ.Simulator.Utils;

    public class DataManager : IDataManager
    {
        private Random randomGen;

        public DataManager()
        {
            this.randomGen = new Random();
        }

        // You cannot have Constructor dependency
        // because Autofac returns error for circular dependencies reference
        public ISensorManager SensorManager { get; set; }

        public SensorDto GenerateSensorData(Guid sensorId)
        {
            SensorMapInfo sensor = this.SensorManager.Sensors.FirstOrDefault(s => s.SensorId == sensorId);

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
            int sensorData = Constants.DEFAULT_START_RANGE;

            int randomNumber = randomGen.Next(startRange, endRange);

            switch (typeGenerator)
            {
                case GenMethodTypeEnum.Random:
                    sensorData = randomNumber;
                    break;
                case GenMethodTypeEnum.Sin:
                    sensorData = (int)Math.Abs(Math.Sin(randomNumber) * Constants.DEFAULT_END_RANGE);
                    break;
                case GenMethodTypeEnum.Cos:
                    sensorData = (int)Math.Abs(Math.Cos(randomNumber) * Constants.DEFAULT_END_RANGE);
                    break;
            }

            return sensorData;
        }
    }
}
