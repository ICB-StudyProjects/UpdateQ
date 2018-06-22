namespace UpdateQ.Model.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using UpdateQ.Common;
    using UpdateQ.Common.Constants;

    public class TimeSeriesNode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SensorId { get; set; }

        public TimeSeriesType? Type { get; set; }

        [Required(ErrorMessage = GlobalConstants.PropIsRequiredErrorMessage)]
        [StringLength(20, MinimumLength = 3, 
            ErrorMessage = GlobalConstants.StringValidationMessage)]
        public string Name { get; set; }

        public int InfoNodeId { get; set; }
        public InfoNode InfoNode { get; set; }
    }
}
