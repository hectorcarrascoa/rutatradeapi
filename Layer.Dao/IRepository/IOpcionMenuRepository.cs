using Layer.Entity;
using Layer.Entity.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Dao.IRepository
{
    public interface IOpcionMenuRepository : IGenericRepository<Navigation>
    {
        Task<Navigation> GetOpciones();
    }
}
