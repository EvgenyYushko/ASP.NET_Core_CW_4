using Meetup.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.DAL.Patterns.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> CreateAsync(TEntity item);
        Task<TEntity> UpdateAsync(TEntity item);
        Task DeleteAsync(TEntity entity);
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetByIdAsync(Guid id);
    }
}
