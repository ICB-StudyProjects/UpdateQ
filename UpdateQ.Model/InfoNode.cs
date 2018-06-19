namespace UpdateQ.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using UpdateQ.Common.Constants;

    public class InfoNode
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3,
            ErrorMessage = GlobalConstants.StringValidationMessage)]
        public string Name { get; set; }

        public DateTime CreatedOn { get; private set; }
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
