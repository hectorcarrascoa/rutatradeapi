using System;
using System.Collections.Generic;

namespace Layer.Entity
{
    public partial class Profile:Audit,IEntity
    {
        public Profile()
        {
            User = new HashSet<User>();
        }

        public long Id { get; set; }
        public long IdClient { get; set; }
        public string ProfileName { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
