using BoardGameManager.EntityFramework.DbContexts;

namespace BoardGameManager.EntityFramework.Factories
{
    public interface IDbContextFactory
    {
        IBoardGameDbContext Create();
    }
}