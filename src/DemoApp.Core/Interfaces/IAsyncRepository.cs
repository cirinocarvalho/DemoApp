using DemoApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DemoApp.Core.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity<T>
    {
        Task<T> GetByIdAsync(T id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
