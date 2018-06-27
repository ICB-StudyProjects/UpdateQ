namespace UpdateQ.Model.DTOs
{
    using System.Collections.Generic;
    using UpdateQ.Model.Entities;

    public class NodesReadDTO
    {
        public string Label { get; set; }

        public ICollection<NodesReadDTO> Items { get; set; }
        public ICollection<NodeTimeSeriesReadDTO> TSNodes { get; set; }

        public NodesReadDTO()
        {
            this.Items = new HashSet<NodesReadDTO>();
            this.TSNodes = new HashSet<NodeTimeSeriesReadDTO>();
        }
    }
}
