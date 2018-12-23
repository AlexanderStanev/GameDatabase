using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDatabase.Data.Core;
using GamesDatabase.Data;                                                                                                                                                                                                                                                                                                                     
using Microsoft.EntityFrameworkCore;

namespace GamesDatabase.Data
{
    public class DbRepository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : class
    {
        private readonly GamesDatabaseContext context;
        private readonly DbSet<TEntity> dbSet;

        public DbRepository(GamesDatabaseContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<TEntity>();
        }

        public Task AddAsync(TEntity entity)
        {
            return this.dbSet.AddAsync(entity);
        }

        public IQueryable<TEntity> All()
        {
            return this.dbSet;
        }

        public void Delete(TEntity entity)
        {
            this.dbSet.Remove(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            return this.context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}