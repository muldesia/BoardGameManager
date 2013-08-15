using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BoardGameManager.Domain.Entities
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
            OwnedBoardGames = new Collection<BoardGame>();
        }

        public int PersonId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<BoardGame> OwnedBoardGames { get; set; }
    }
}
