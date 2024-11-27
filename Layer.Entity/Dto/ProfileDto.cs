using System;
using System.Collections.Generic;
using System.Text;

namespace Layer.Entity.Dto
{
    public class ProfileDto
    {
        public ProfileDto()
        {
            User = new HashSet<UserDto>();
        }

        public long Id { get; set; }
        public long IdClient { get; set; }
        public string ProfileName { get; set; }
        public bool Active { get; set; }
        public DateTime LoadDate { get; set; }
        public string LoadUser { get; set; }
        public DateTime? UpdDate { get; set; }
        public string UpdUser { get; set; }

        public virtual ICollection<UserDto> User { get; set; }
    }
}
