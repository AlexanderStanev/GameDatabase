namespace GameDatabase.Data
{
    using System;
    using System.Threading.Tasks;

    using GameDatabase.Data.Common;
    using GamesDatabase.Data;
    using Microsoft.EntityFrameworkCore;

    public class DbQueryRunner : IDbQueryRunner
    {
        public DbQueryRunner(GamesDatabaseContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public GamesDatabaseContext Context { get; set; }

        public Task RunQueryAsync(string query, params object[] parameters)
        {
            return this.Context.Database.ExecuteSqlRawAsync(query, parameters);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Context?.Dispose();
            }
        }
    }
}
