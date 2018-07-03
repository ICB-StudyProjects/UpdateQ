namespace UpdateQ.Simulator.Model
{
    using System;
    using Newtonsoft.Json;
    using UpdateQ.Simulator.Utils;

    public class SensorMapInfo
    {
        public Guid SensorId { get; set; }
        public GenMethodTypeEnum TypeGenerator { get; set; }
        public int StartRange { get; set; }
        public int EndRange { get; set; }
        public TimeSpan Interval { get; set; }

        [JsonConstructor]
        public SensorMapInfo(Guid sensorId)
        {
            this.SensorId = sensorId;
            this.StartRange = Constants.DEFAULT_START_RANGE;
            this.EndRange = Constants.DEFAULT_END_RANGE;
            this.TypeGenerator = Constants.DEFAULT_GENERATOR_METHOD;
            this.Interval = Constants.DEFAULT_INTERVAL;
        }

        public SensorMapInfo(Guid sensorId, int startRange, 
            int endRange, TimeSpan interval)
        {
            this.SensorId = sensorId;
            this.StartRange = startRange;
            this.EndRange = endRange;
            this.TypeGenerator = Constants.DEFAULT_GENERATOR_METHOD;
            this.Interval = interval;
        }
    }
}
