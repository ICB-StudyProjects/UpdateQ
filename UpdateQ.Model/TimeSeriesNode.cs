namespace UpdateQ.Model
{
    using System;
    using UpdateQ.Model.Common;

    public class TimeSeriesNode
    {
        public Guid SensorId { get; set; }
        public TimeSeriesType? Type { get; set; }
        public string Name { get; set; }

        public int InfoNodeId { get; set; }
        public InfoNode InfoNode { get; set; }
    }
}
