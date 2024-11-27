using Layer.Entity;
using Layer.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Dao.IRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<UserDto> UserAuthenticationAsync(string userName, string userPassword);
        Task<IEnumerable<User>> GetUserByCompany(FiltroReporteDto filter);
        Task<IEnumerable<UserDto>> GetAllUserAsync(FiltroReporteDto filter);
    }
}
