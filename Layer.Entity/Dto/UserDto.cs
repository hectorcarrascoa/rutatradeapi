using System;
using System.Collections.Generic;
using System.Text;

namespace Layer.Entity.Dto
{
    public class UserDto
    {
        public UserDto()
        {
        }

        public long Id { get; set; }
        public long IdClient { get; set; }
        public string Client { get; set; }
        public long IdProfile { get; set; }
        public string Profile { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserNames { get; set; }
        public string UserLastNames { get; set; }
        public string FullName { get; set; }
        public string UserTitle { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string UserPicture { get; set; }
        public bool? UserFirstAccess { get; set; }
        public string BackGround { get; set; }
        public int? IdPollinator { get; set; }
        public string Token { get; set; }
        public DateTime LoadDate { get; set; }
        public string LoadUser { get; set; }
        public DateTime? UpdDate { get; set; }
        public string UpdUser { get; set; }
        public bool Active { get; set; }

        public virtual ClientDto IdClientNavigation { get; set; }
        public virtual ProfileDto IdProfileNavigation { get; set; }
        
    }
}
