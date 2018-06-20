namespace UpdateQ.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using UpdateQ.Common;
    using UpdateQ.Common.Constants;

    public class User
    {
        [Key]
        public Guid Id { get; set; }

        // TODO: Added them to the auth server's user model (claims)
        // public Guid SubjectId { get; set; }
        // public string Username { get; set; }
        // public string Password { get; set; }
        // public string Email { get; set; }

        [Required(ErrorMessage = GlobalConstants.PropIsRequiredErrorMessage)]
        [StringLength(50,
            MinimumLength = 1,
            ErrorMessage = GlobalConstants.StringValidationMessage)]
        public string FirstName { get; set; }

        [StringLength(50,
            ErrorMessage = GlobalConstants.StringValidationMessage,
            MinimumLength = 1)]
        public string LastName { get; set; }

        [Range(1, 120, ErrorMessage = GlobalConstants.NumberValidationMessage)]
        public int? Age { get; set; }

        public DateTime? BirthDay { get; set; }
        public GenderType? Gender { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<InfoNode> InfoNodes { get; set; }

        public User()
        {
            this.InfoNodes = new HashSet<InfoNode>();
        }
    }
}
