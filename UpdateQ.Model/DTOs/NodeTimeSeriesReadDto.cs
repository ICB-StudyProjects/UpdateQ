namespace UpdateQ.Model.DTOs
{
    using System;
    using UpdateQ.Common;

    public class NodeTimeSeriesReadDTO
    {
        public Guid SensorId { get; set; }
        public string Name { get; set; }
        public TimeSeriesType? Type { get; set; }
    }
}
