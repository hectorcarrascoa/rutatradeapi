using System;
using System.Collections.Generic;

namespace Layer.Entity
{
    public partial class Client : Audit, IEntity
    {
        public Client()
        {
            User = new HashSet<User>();
        }

        public long Id { get; set; }
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }
        public long? IdCity { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public bool Active { get; set; }
        

        public virtual City IdCityNavigation { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
