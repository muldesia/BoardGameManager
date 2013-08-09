using System.Collections.Generic;

namespace BoardGameManager.EntityFramework.Entities
{
    public class Person
    {
        public int PersonId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<BoardGame> OwnedBoardGames { get; set; }
    }
}
