namespace UpdateQ.Simulator.Core
{
    using System;
    using System.Linq;
    using UpdateQ.Simulator.Core.Interfaces;

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
            string command = cmdArgs[0];

            switch(command)
            {
                case "Start":
                    // {Cmd} {SensorId}
                    this.outputMsg = this.sensorManager.Start(cmdArgs[1]);
                    break;
                case "Stop":
                    // {Cmd} {SensorId}
                    this.outputMsg = this.sensorManager.Stop(cmdArgs[1]);
                    break;
                case "Sensor-Data":
                    // {Cmd} {SensorId} {StartRange} {EndRange} {Interval (seconds)}
                    this.outputMsg = this.sensorManager.AddSensorInputData(cmdArgs.Skip(1).ToArray());
                    break;
                case "Gen-Conf":
                    // {Cmd} {Method} {SensorId}
                    // Methods - {Random: 1}, {Sin: 2}, {Cos: 3}
                    this.outputMsg = this.sensorManager.ChangeGeneratorSensor(cmdArgs[1], cmdArgs[2]);
                    break;
                case "Gen-Conf-All":
                    // {Cmd} {Method}
                    // Methods - {Random: 1}, {Sin: 2}, {Cos: 3}
                    this.outputMsg = this.sensorManager.ChangeGeneratorAllSensors(cmdArgs[1]);
                    break;
                case "Shutdown":
                    this.outputMsg = this.sensorManager.Shutdown();
                    this.isRunning = false;
                    break;
            }

            Console.WriteLine(this.outputMsg);
        }
    }
}
