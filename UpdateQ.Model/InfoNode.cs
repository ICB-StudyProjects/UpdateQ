namespace UpdateQ.Model
{
    using System;
    using System.Collections.Generic;

    public class InfoNode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public ICollection<InfoNode> ChildInfoNodes { get; set; }
        public ICollection<TimeSeriesNode> TimeSeriesNodes { get; set; }

        public InfoNode()
        {
            this.CreatedOn = DateTime.Now;
            this.ChildInfoNodes = new HashSet<InfoNode>();
            this.TimeSeriesNodes = new HashSet<TimeSeriesNode>();
        }
    }
}
