using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TDH.Basketball.Game.EF.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> GetAsync(int Id);

        Task<IEnumerable<TEntity>> GetByExtensionFuncAsync(string Name, Func<string, Task<IEnumerable<TEntity>>> FindEntityByExtensionFunc);

        Task<TEntity> CreateAsync(TEntity Entity);

        Task<bool> CreateRangeAsync(IEnumerable<TEntity> Entities);

        Task<bool> UpdateAsync(int Id, TEntity Entity);


        Task<bool> DeleteAsync(TEntity Entity);
        Task<bool> DeleteRangeAsync(List<TEntity> Entities);

        Task<bool> SaveChangesAsync();



    }
}
