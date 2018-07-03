namespace UpdateQ.Simulator.Utils
{
    using System;

    public static class Operations
    {
        public static string SuccessfullyStartedSensor(Guid sensorId)
            => $"Successfully started sending data to {sensorId.ToString()}";

        public static string SuccessfullyStopedSensor(Guid sensorId)
            => $"Successfully stoped sending data to {sensorId.ToString()}";

        public static string SuccessfullyChangedSensorData(Guid sensorId)
            => $"Sensor {sensorId.ToString()} had successfully changed its data";

        public static string SuccessfullyInitAllSensors
            => "All default sensors default are initizlized";


        public static string SensorNotRegistered(Guid sensorId)
            => $"The sensor is not registered - {sensorId.ToString()}";

        public static string InvalidMethodGenerator(string generatorTypeStr)
            => $"The given method - {generatorTypeStr} - is not valid";

        public static string SuccessfullyChangedGenerator(Guid sensorId, GenMethodTypeEnum generatorType)
            => $"Sensor {sensorId.ToString()} change generator method to - {Enum.GetName(typeof(GenMethodTypeEnum), generatorType)}";

        public static string SuccessfullyChangedGeneratorAllSensors(GenMethodTypeEnum generatorType)
            => $"All sensors changed generator method to - {Enum.GetName(typeof(GenMethodTypeEnum), generatorType)}";

        public static string AllSystemShutdown()
            => $"All systems shuted down";
    }
}
