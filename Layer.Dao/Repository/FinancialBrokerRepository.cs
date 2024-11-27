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
    public class FinancialBrokerRepository : GenericRepository<FinancialBroker>, IFinancialBrokerRepository
    {
        private readonly DataContext _dbContext;

        public FinancialBrokerRepository(DataContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<FinancialBroker>> GetItems(FiltroReporteDto filtro)
        {
            var items = await (from co in _dbContext.FinancialBroker
                               where co.Id != 0 && co.Estado == true
                               select co).OrderBy(o=>o.Symbol).ToListAsync();
            return items;
        }
    }
}
