using System.Data;
using System.Data.Entity;
using BoardGameManager.EntityFramework.Entities;
using BoardGameManager.EntityFramework.Mappings;

namespace BoardGameManager.EntityFramework.DbContexts
{
    public class BoardGameDbContext : DbContext, IBoardGameDbContext
    {
        public IDbSet<BoardGame> BoardGames { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BoardGameMappings());
            modelBuilder.Configurations.Add(new PersonMappings());

            base.OnModelCreating(modelBuilder);
        }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        public void SetAdd(object entity)
        {
            Entry(entity).State = EntityState.Added;
        }
    }
}
