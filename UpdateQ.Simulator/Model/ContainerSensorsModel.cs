namespace UpdateQ.Simulator.Model
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class ContainerSensorsModel
    {
        [JsonProperty("userId")]
        public Guid UserId { get; set; }

        [JsonProperty("sensors")]
        public ICollection<SensorMapInfo> Sensors { get; set; }
    }
}
