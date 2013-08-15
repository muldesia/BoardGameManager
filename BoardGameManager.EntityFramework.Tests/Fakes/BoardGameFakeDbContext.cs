using System.Data.Entity;
using BoardGameManager.EntityFramework.DbContexts;
using BoardGameManager.EntityFramework.Entities;

namespace BoardGameManater.EntityFramework.Tests.Fakes
{
    public class BoardGameFakeDbContext : IBoardGameDbContext
    {
        public IDbSet<BoardGame> BoardGames { get; set; }

        public BoardGameFakeDbContext()
        {
            BoardGames = new BoardGameFakeDbSet();
        }

        public int SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void SetModified(object entity)
        {
            throw new System.NotImplementedException();
        }

        public void SetAdd(object entity)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
        }

    }
}