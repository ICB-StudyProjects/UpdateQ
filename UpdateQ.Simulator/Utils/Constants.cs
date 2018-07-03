namespace UpdateQ.Simulator.Utils
{
    using System;
    using System.IO;

    public static class Constants
    {
        public static int DEFAULT_START_RANGE = 0;

        public static int DEFAULT_END_RANGE = 100;

        public static GenMethodTypeEnum DEFAULT_GENERATOR_METHOD = GenMethodTypeEnum.Random;

        public static TimeSpan DEFAULT_INTERVAL = TimeSpan.FromSeconds(3.0);

        public static string APPSETTING_FULL_PATH = Directory.GetCurrentDirectory() + @"../../../../appsettings.json";

    }
}
