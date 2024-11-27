using Layer.Dao.IRepository;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business
{
    public class CountryBusiness
    {
        #region ----- Declaración -----
        private readonly ICountryRepository countryRepository;
        #endregion

        #region ----- Constructores -----
        public CountryBusiness(ICountryRepository repository)
        {
            countryRepository = repository;
        }
        #endregion

        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await countryRepository.GetCountries();
        }
    }
}
