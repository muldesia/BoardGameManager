using System.Data.Entity;
using BoardGameManager.EntityFramework.DbContexts;

namespace BoardGameManager.EntityFramework.DatabaseInitializers
{
    public class DropCreateBoardGameDatabaseInitializer : DropCreateDatabaseAlways<BoardGameContext>
    {
        protected override void Seed(BoardGameContext context)
        {

            base.Seed(context);
        }
    }
}