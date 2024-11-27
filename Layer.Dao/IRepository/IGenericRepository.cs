using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Layer.Dao.IRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        Task<IEnumerable<TEntity>> GetAllAsync();

        TEntity GetById(int id);

        Task<TEntity> GetByIdAsync(int id);

        TEntity Create(TEntity entity);

        Task<TEntity> CreateAsync(TEntity entity);

        void Update(int id, TEntity entity);

        Task<bool> UpdateAsync(int id, TEntity entity);

        void Delete(int id);

        Task<bool> SavAsync();

        bool CreateBulk(List<TEntity> entities);
        
    }
}
