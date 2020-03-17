using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDH.Basketball.Game.EF.Core;

namespace TDH.Basketball.Game.EF.Repository
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly TDHDBContext _context;
        protected readonly ILogger<TEntity> _logger;
        public GenericRepository(TDHDBContext context, 
                                ILogger<TEntity> logger)
        {
            this._context = context;
            this._logger = logger;
        }

        public async Task<TEntity> CreateAsync(TEntity Entity)
        {
            try
            {
                var entity = _context.Set<TEntity>().Add(Entity);
                await _context.SaveChangesAsync();
                return entity.Entity;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // log error later
                _logger.LogError(ex.Message);
                return null;

            }
        }

        public async Task<bool> CreateRangeAsync(List<TEntity> Entities)
        {
            try
            {
                 _context.Set<TEntity>().AddRange(Entities);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // log error later
                _logger.LogError(ex.Message);
                return false;

            }
        }

        public async virtual Task<bool> DeleteAsync(TEntity Entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(Entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }

        }

        public async virtual Task<bool> DeleteRangeAsync(List<TEntity> Entities)
        {
            try
            {
                _context.Set<TEntity>().RemoveRange(Entities);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }


        public async virtual Task<List<TEntity>> GetAsync()
        {
            
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async virtual Task<TEntity> GetAsync(int Id)
        {
            return await _context.Set<TEntity>().FindAsync(Id);
        }

        

        public async Task<bool> UpdateAsync(int Id, TEntity Entity)
        {
            try
            {
                _context.Entry(Entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }

        }

        public async Task<bool> SaveChangesAsync()
        {
            var returnValue = await this._context.SaveChangesAsync();

            return bool.Parse(returnValue.ToString());
        }

        public async Task<List<TEntity>> GetByExtensionFuncAsync(string Name, Func<string, Task<List<TEntity>>> FindEntityByExtensionFunc)
        {
            return await FindEntityByExtensionFunc(Name);
        }

        
    }
}
