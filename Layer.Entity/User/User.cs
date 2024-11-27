using System;
using System.Collections.Generic;

namespace Layer.Entity
{
    public partial class User:Audit,IEntity
    {
        public User()
        {
        }

        public long Id { get; set; }
        public long IdClient { get; set; }
        public long IdProfile { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserNames { get; set; }
        public string UserLastNames { get; set; }
        public string UserTitle { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string UserPicture { get; set; }
        public bool? UserFirstAccess { get; set; }
        public bool Active { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual Profile IdProfileNavigation { get; set; }
    }
}
