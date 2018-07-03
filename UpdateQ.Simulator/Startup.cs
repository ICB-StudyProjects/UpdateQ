namespace UpdateQ.Simulator
{
    using Microsoft.Extensions.DependencyInjection;
    using UpdateQ.Simulator.Core;
    using UpdateQ.Simulator.Core.Interfaces;

    class Startup
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine(new SensorManager());

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
