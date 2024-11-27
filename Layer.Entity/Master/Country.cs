using System;
using System.Collections.Generic;

namespace Layer.Entity
{
    public partial class Country : Audit, IEntity
    {
        public Country()
        {
            City = new HashSet<City>();
        }

        public long Id { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public bool Active { get; set; }
        

        public virtual ICollection<City> City { get; set; }
    }
}
