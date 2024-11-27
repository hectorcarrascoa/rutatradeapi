using System;
using System.Collections.Generic;
using System.Text;

namespace Layer.Entity.Dto
{
    public class ClientDto
    {
        public ClientDto()
        {
            //User = new HashSet<UserDto>();
        }

        public long Id { get; set; }
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }
        public long? IdCity { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public bool Active { get; set; }
        //public DateTime LoadDate { get; set; }
        //public string LoadUser { get; set; }
        //public DateTime? UpdDate { get; set; }
        //public string UpdUser { get; set; }

        //public virtual CityDto IdCityNavigation { get; set; }
        //public virtual ICollection<UserDto> User { get; set; }
    }
}
