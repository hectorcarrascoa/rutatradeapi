using Layer.Dao.IRepository;
using Layer.Entity;
using Layer.Entity.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Layer.Dao.Repository
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        private readonly DataContext _dbContext;

        public CityRepository(DataContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<City>> GetCities(int idCountry)
        {
            var items = await (from co in _dbContext.City.Include("IdCountryNavigation")
                               where co.IdCountry == idCountry
                               select co).ToListAsync();
            return items;
        }
    }
}
