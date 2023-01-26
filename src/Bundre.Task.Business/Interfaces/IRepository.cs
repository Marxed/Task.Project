using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bundre.Tasks.Business.Models;

namespace Bundre.Tasks.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Create(TEntity entity);
        Task<TEntity> GetById(Guid id);
        Task<List<TEntity>> GetAll();
        Task UpdateEntity(TEntity entity);
        Task RemoveEntity(Guid id);
        Task<IEnumerable<TEntity>> SearchGeneric(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}