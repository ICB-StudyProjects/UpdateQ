namespace UpdateQ.Simulator.Core
{
    using System;
    using System.Linq;
    using UpdateQ.Simulator.Core.Interfaces;
    using UpdateQ.Simulator.Utils;

    public class Engine : IEngine
    {
        private ISensorManager sensorManager;
        private string outputMsg;
        private bool isRunning;

        public Engine(ISensorManager ISensorManager)
        {
            this.sensorManager = ISensorManager;
            this.isRunning = true;
        }

        public void Run()
        {
            this.outputMsg = this.sensorManager.RegisterSensors().Result;
            Console.WriteLine(this.outputMsg);

            while (this.isRunning)
            {
                string[] cmdArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                ExecuteCommand(cmdArgs);
            }
        }

        public void ExecuteCommand(string[] cmdArgs)
        {
            string command = cmdArgs.FirstOrDefault()?.ToUpper();

            // TODO: Add regex validations for the commands
            switch(command)
            {
                case "START":
                    // {Cmd} {SensorId}
                    this.outputMsg = this.sensorManager.Start(cmdArgs[1]);
                    break;
                case "STOP":
                    // {Cmd} {SensorId}
                    this.outputMsg = this.sensorManager.Stop(cmdArgs[1]);
                    break;
                case "SENSOR-DATA":
                    // {Cmd} {SensorId} {StartRange} {EndRange} {Interval (seconds)}
                    this.outputMsg = this.sensorManager.AddSensorInputData(cmdArgs.Skip(1).ToArray());
                    break;
                case "GEN-CONF":
                    // {Cmd} {Method} {SensorId}
                    // Methods - {Random: 1}, {Sin: 2}, {Cos: 3}
                    this.outputMsg = this.sensorManager.ChangeGeneratorSensor(cmdArgs[1], cmdArgs[2]);
                    break;
                case "GEN-CONF-ALL":
                    // {Cmd} {Method}
                    // Methods - {Random: 1}, {Sin: 2}, {Cos: 3}
                    this.outputMsg = this.sensorManager.ChangeGeneratorAllSensors(cmdArgs[1]);
                    break;
                case "SHUTDOWN":
                    this.outputMsg = this.sensorManager.Shutdown();
                    this.isRunning = false;
                    break;
                default:
                    this.outputMsg = Operations.InvalidCommand;
                    break;
            }

            Console.WriteLine(this.outputMsg);
        }
    }
}
