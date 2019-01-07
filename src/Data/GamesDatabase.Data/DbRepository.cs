using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamesDatabase.Data.Core;
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
            dbSet = this.context.Set<TEntity>();
        }

        public Task AddAsync(TEntity entity)
        {
            return dbSet.AddAsync(entity);
        }

        public IQueryable<TEntity> All()
        {
            return dbSet;
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}