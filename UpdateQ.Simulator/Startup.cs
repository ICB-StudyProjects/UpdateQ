namespace UpdateQ.Simulator
{
    using Autofac;
    using UpdateQ.Simulator.Core;
    using UpdateQ.Simulator.Core.Interfaces;

    class Startup
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            RegisterDependencies();

            using (var scope = Container.BeginLifetimeScope())
            {
                var engine = scope.Resolve<IEngine>();
                engine.Run();
            }
        }

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<RequestManager>().As<IRequestManager>();
            builder.RegisterType<SensorManager>().As<ISensorManager>();
            builder.RegisterType<Engine>().As<IEngine>();

            Container = builder.Build();
        }
    }
}
