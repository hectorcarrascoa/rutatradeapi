using Layer.Dao.IRepository;
using Layer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Npgsql.Bulk;

namespace Layer.Dao.Repository
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DataContext _dbContext;

        public GenericRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefault(e => e.Id == id);
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            return _dbContext.Set<TEntity>().FirstOrDefaultAsync(e=> e.Id == id);
        }

        public TEntity Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await  _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public void Update(int id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            _dbContext.SaveChanges();
        }

        public async Task<bool> UpdateAsync(int id, TEntity entity)
        {
            bool result = false;
            try
            {
                _dbContext.Set<TEntity>().Update(entity);
                await _dbContext.SaveChangesAsync();
                result = true;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<bool> SavAsync()
        {
            bool result = false;

            try
            {
                await _dbContext.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public void Delete(int id)
        {
            var entity = _dbContext.Set<TEntity>().Find(id);
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public bool CreateBulk(List<TEntity> entities)
        {
            bool result = false;
            try
            {
                using var transaction = _dbContext.Database.BeginTransaction();
                var uploader = new NpgsqlBulkUploader(_dbContext);
                uploader.Insert(entities);
                transaction.Commit();
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
