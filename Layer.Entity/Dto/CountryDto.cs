using System;
using System.Collections.Generic;
using System.Text;

namespace Layer.Entity.Dto
{
    public class CountryDto
    {
        public CountryDto()
        {
            City = new HashSet<CityDto>();
        }

        public long Id { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<CityDto> City { get; set; }
    }
}
