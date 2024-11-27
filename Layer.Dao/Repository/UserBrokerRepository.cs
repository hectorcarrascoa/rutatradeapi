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
    public class UserBrokerRepository : GenericRepository<UserBroker>, IUserBrokerRepository
    {
        private readonly DataContext _dbContext;

        public UserBrokerRepository(DataContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<UserBroker>> GetItems(FiltroReporteDto filtro)
        {
            var items = await (from co in _dbContext.UserBroker
                               where co.Estado == true
                               select co).OrderBy(o=>o.Label).ToListAsync();
            return items;
        }
    }
}
