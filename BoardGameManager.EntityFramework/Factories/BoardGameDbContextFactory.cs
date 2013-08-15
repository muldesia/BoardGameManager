using BoardGameManager.EntityFramework.DbContexts;

namespace BoardGameManager.EntityFramework.Factories
{
    public class BoardGameDbContextFactory : IDbContextFactory
    {
        public IBoardGameDbContext Create()
        {
            return new BoardGameDbContext();
        }
    }
}