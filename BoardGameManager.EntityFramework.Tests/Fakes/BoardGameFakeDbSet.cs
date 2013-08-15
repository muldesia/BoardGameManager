using System.Linq;
using BoardGameManager.EntityFramework.Entities;

namespace BoardGameManater.EntityFramework.Tests.Fakes
{
    public class BoardGameFakeDbSet : FakeDbSet<BoardGame>
    {
        public override BoardGame Find(params object[] keyValues)
        {
            var keyValue = (int) keyValues.FirstOrDefault();
            return this.SingleOrDefault(p => p.BoardGameId == keyValue);
        }
    }
}