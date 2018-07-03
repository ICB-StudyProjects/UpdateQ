namespace UpdateQ.Simulator
{
    using Microsoft.Extensions.DependencyInjection;
    using UpdateQ.Simulator.Core;
    using UpdateQ.Simulator.Core.Interfaces;

    class Startup
    {
        static void Main(string[] args)
        {
            IRequestManager requestManager = new RequestManager();
            ISensorManager sensorManager = new SensorManager(requestManager);
            IEngine engine = new Engine(sensorManager);

            engine.Run();

            //RegisterServices();
        }

        public static void RegisterServices()
        {
            // TODO: Add DI
            //var engineProvider = new ServiceCollection()
            //    .AddSingleton<IEngine, Engine>()
            //    .AddSingleton<ISensorManager, SensorManager>()
            //    .BuildServiceProvider();
        }
    }
}
