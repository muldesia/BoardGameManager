using System.Data.Entity;
using BoardGameManager.EntityFramework.Entities;
using BoardGameManager.EntityFramework.Mappings;

namespace BoardGameManager.EntityFramework.DbContexts
{
    public class BoardGameContext : DbContext
    {
        public DbSet<BoardGame> BoardGames { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BoardGameMappings());
            modelBuilder.Configurations.Add(new PersonMappings());

            base.OnModelCreating(modelBuilder);
        }
    }
}
