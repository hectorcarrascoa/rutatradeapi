using System;
using System.Collections.Generic;

namespace Layer.Entity
{
    public partial class City : Audit, IEntity
    {
        public City()
        {
            Client = new HashSet<Client>();
        }

        public long Id { get; set; }
        public long IdCountry { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public bool Active { get; set; }
        

        public virtual Country IdCountryNavigation { get; set; }
        public virtual ICollection<Client> Client { get; set; }
    }
}
