namespace UpdateQ.Simulator
{
    using Autofac;
    using UpdateQ.Simulator.Core;
    using UpdateQ.Simulator.Core.Managers;
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

            builder.RegisterType<SensorManager>().As<ISensorManager>().SingleInstance();
            builder.RegisterType<TaskManager>().As<ITaskManager>().SingleInstance();
            builder.RegisterType<RequestManager>().As<IRequestManager>().SingleInstance();

            builder.RegisterType<DataManager>().As<IDataManager>()
                .InstancePerLifetimeScope()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();

            Container = builder.Build();
        }
    }
}
