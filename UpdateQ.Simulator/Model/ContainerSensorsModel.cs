namespace UpdateQ.Simulator.Model
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class ContainerSensorsModel
    {
        [JsonProperty("sensors")]
        public ICollection<SensorMapInfo> Sensors { get; set; }
    }
}
