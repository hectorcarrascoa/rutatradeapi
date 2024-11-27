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
    public class IndicatorRepository : GenericRepository<Indicator>, IIndicatorRepository
    {
        private readonly DataContext _dbContext;

        public IndicatorRepository(DataContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<Indicator>> GetItems(FiltroReporteDto filtro)
        {
            var items = await (from co in _dbContext.Indicator
                               where co.Estado == true
                               select co).OrderBy(o=>o.Name).ToListAsync();
            return items;
        }
    }
}
