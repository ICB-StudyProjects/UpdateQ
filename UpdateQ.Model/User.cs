namespace UpdateQ.Model
{
    using System;
    using System.Collections.Generic;
    using UpdateQ.Model.Common;

    public class User
    {
        public Guid Id { get; set; }

        // TODO: Added them to the auth server's user model (claims)
        // public Guid SubjectId { get; set; }
        // public string Username { get; set; }
        // public string Password { get; set; }
        // public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public DateTime? BirthDay { get; set; }
        public GenderType? Gender { get; set; }

        public ICollection<InfoNode> InfoNodes { get; set; }

        public User()
        {
            this.InfoNodes = new HashSet<InfoNode>();
        }
    }
}
