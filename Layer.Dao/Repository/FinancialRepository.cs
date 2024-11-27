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
    public class FinancialRepository : GenericRepository<FinancialAsset>, IFinancialRepository
    {
        private readonly DataContext _dbContext;

        public FinancialRepository(DataContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<FinancialAsset>> GetItems(FiltroReporteDto filtro)
        {
            var items = await (from co in _dbContext.FinancialAsset
                               where co.Id != 99 && co.Estado == true
                               select co).OrderBy(o=>o.Name).ToListAsync();
            return items;
        }
    }
}
