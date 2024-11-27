using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Layer.Entity.Dto
{
    public class CityDto
    {
        public long Id { get; set; }
        public long IdCountry { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }

        public bool Active { get; set; }

        public virtual CountryDto IdCountryNavigation { get; set; }
    }
}
