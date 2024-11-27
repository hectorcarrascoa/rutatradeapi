using Layer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Dao.IRepository
{
    public interface IProfileRepository : IGenericRepository<Profile>
    {
        Task<IEnumerable<Profile>> GetProfiles(int idClient);
    }
}
