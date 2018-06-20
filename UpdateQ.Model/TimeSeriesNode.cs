namespace UpdateQ.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using UpdateQ.Common;
    using UpdateQ.Common.Constants;

    public class TimeSeriesNode
    {
        [Key]
        public Guid SensorId { get; set; }

        public TimeSeriesType? Type { get; set; }

        [Required(ErrorMessage = GlobalConstants.PropIsRequiredErrorMessage)]
        [StringLength(20, MinimumLength = 3, 
            ErrorMessage = GlobalConstants.StringValidationMessage)]
        public string Name { get; set; }

        public int InfoNodeId { get; set; }
        public InfoNode InfoNode { get; set; }

        public TimeSeriesNode()
        {
            this.SensorId = Guid.NewGuid();
        }
    }
}
