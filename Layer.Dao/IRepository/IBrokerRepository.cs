using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Dao.IRepository
{
    public interface IBrokerRepository : IGenericRepository<Broker>
    {
        Task<IEnumerable<Broker>> GetItems(FiltroReporteDto filtro);
    }
}
