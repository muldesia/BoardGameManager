using System.Collections.Generic;

namespace BoardGameManager.EntityFramework.Entities
{
    public class Person
    {
        public Person(string name)
        {
            this.Name = Name;
        }

        protected Person()
        {
            
        }

        public int PersonId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<BoardGame> OwnedBoardGames { get; set; }
    }
}
