﻿namespace UpdateQ.Simulator.Utils
{
    using System;

    public static class Operations
    {
        #region Successful operations
        public static string SuccessfullyStartedSensor(Guid sensorId)
            => $"Successfully started sending data to {sensorId.ToString()}";

        public static string SuccessfullyStopedSensor(Guid sensorId)
            => $"Successfully stoped sending data to {sensorId.ToString()}";

        public static string SuccessfullyChangedSensorData(Guid sensorId)
            => $"Sensor {sensorId.ToString()} had successfully changed its data";

        public static string SuccessfullyInitAllSensors
            => "All default sensors are initizlized";

        public static string StartedSendingSensorData(Guid sensorId)
            => $"Started sending sensor {sensorId} data";

        public static string StoppedSendingSensorData(Guid sensorId)
            => $"Stopped sending sensor {sensorId} data";

        public static string SuccessfullyChangedGenerator(Guid sensorId, GenMethodTypeEnum generatorType)
            => $"Sensor {sensorId.ToString()} change generator method to - {Enum.GetName(typeof(GenMethodTypeEnum), generatorType)}";

        public static string SuccessfullyChangedGeneratorAllSensors(GenMethodTypeEnum generatorType)
            => $"All sensors changed generator method to - {Enum.GetName(typeof(GenMethodTypeEnum), generatorType)}";
        #endregion


        #region Invalid Operations
        public static string InvalidMethodGenerator(string generatorTypeStr)
            => $"The given method - {generatorTypeStr} - is not valid";

        public static string InvalidCommand
            => $"The given command is not valid";

        public static string SensorNotRegistered(Guid sensorId)
           => $"The sensor is not registered - {sensorId.ToString()}";

        public static string SensorIsActive(Guid sensorId)
           => $"Sensor {sensorId.ToString()} IS already sending data";

        public static string SensorIsNotActive(Guid sensorId)
           => $"Sensor {sensorId.ToString()} is NOT sending currently data";
        #endregion

        // Shutdown
        public static string AllSystemShutdown()
            => $"All systems shuted down";
    }
}
