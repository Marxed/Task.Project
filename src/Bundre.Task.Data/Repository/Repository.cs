using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bundre.Tasks.Business.Interfaces;
using Bundre.Tasks.Business.Models;
using Bundre.Tasks.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Bundre.Tasks.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly TaskContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(TaskContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> SearchGeneric(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }
        public virtual async Task<List<TEntity>> GetAll()
        {
           return await DbSet.ToListAsync();    
        }

        public virtual async Task Create(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public async Task UpdateEntity(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public async Task RemoveEntity(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync(); 
        }

        public void Dispose()
        {
            Db?.Dispose();

        }
    }
}