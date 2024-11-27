using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Dao.IRepository
{
    public interface IBotRepository : IGenericRepository<Bot>
    {
        Task<IEnumerable<Bot>> GetItems(FiltroReporteDto filtro);
    }
}
