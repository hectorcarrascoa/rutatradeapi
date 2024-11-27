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
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        private readonly DataContext _dbContext;

        public CountryRepository(DataContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            try
            {
                var items = await (from co in _dbContext.Country.Include("City")
                                   select co).ToListAsync();
                return items;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
