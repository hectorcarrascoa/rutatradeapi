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
    public class BotRepository : GenericRepository<Bot>, IBotRepository
    {
        private readonly DataContext _dbContext;

        public BotRepository(DataContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<Bot>> GetItems(FiltroReporteDto filtro)
        {
            var items = await (from co in _dbContext.Bot
                               where co.IdUser == filtro.IdUser && co.Estado == true
                               select co).OrderBy(o=>o.Name).ToListAsync();
            return items;
        }
    }
}
