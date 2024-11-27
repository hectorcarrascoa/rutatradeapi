using Layer.Dao.IRepository;
using Layer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Layer.Dao.Repository
{
    public class ProfileRepository : GenericRepository<Profile>, IProfileRepository
    {
        private readonly DataContext _dbContext;

        public ProfileRepository(DataContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<Profile>> GetProfiles(int idClient)
        {
            var items = await (from co in _dbContext.Profile
                               where co.IdClient == idClient
                               && co.Id > 2
                               select co).ToListAsync();
            return items;
        }

    }
}
