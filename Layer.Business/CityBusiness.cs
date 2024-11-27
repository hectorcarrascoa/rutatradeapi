using Layer.Dao.IRepository;
using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business
{
    public class CityBusiness
    {
        #region ----- Declaración -----
        private readonly ICityRepository cityRepository;
        #endregion

        #region ----- Constructores -----
        public CityBusiness(ICityRepository repository)
        {
            cityRepository = repository;
        }
        #endregion

        public async Task<IEnumerable<City>> GetCities(int idCountry)
        {
            return await cityRepository.GetCities(idCountry);
        }
    }
}
