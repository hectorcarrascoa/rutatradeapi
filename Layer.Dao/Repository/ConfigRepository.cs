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
    public class ConfigRepository : GenericRepository<Config>, IConfigRepository
    {
        private readonly DataContext _dbContext;

        public ConfigRepository(DataContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<Config>> GetItems(FiltroReporteDto filtro)
        {
            var items = await (from co in _dbContext.Config
                               where co.IdUser == filtro.IdUser && co.Estado == true
                               && co.Id > 0
                               select co).OrderBy(o=>o.Descripcion).ToListAsync();
            return items;
        }
    }
}
