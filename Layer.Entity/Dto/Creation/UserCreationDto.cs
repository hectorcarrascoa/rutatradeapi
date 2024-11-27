using System;
using System.Collections.Generic;
using System.Text;

namespace Layer.Entity.Dto
{
    public class UserCreationDto
    {
        public long Id { get; set; }
        public long IdClient { get; set; }
        public long IdProfile { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserNames { get; set; }
        public string UserLastNames { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string UserPicture { get; set; }
        public bool? UserFirstAccess { get; set; }
        public DateTime LoadDate { get; set; }
        public string LoadUser { get; set; }
        public DateTime? UpdDate { get; set; }
        public string UpdUser { get; set; }
        public bool Active { get; set; }
    }
}
