namespace UpdateQ.Model.DTOs
{
    using System.Collections.Generic;
    using UpdateQ.Model.Entities;

    public class NodesReadDTO
    {
        public string Name { get; set; }

        public ICollection<InfoNode> Nodes { get; set; }

        public NodesReadDTO()
        {
            this.Nodes = new HashSet<InfoNode>();
        }
    }
}
