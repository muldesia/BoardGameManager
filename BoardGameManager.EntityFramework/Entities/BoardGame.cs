using System.Collections.Generic;
using System.Security.Policy;

namespace BoardGameManager.EntityFramework.Entities
{
    public class BoardGame
    {
        public BoardGame(string Name)

        public int BoardGameId { get; set; }
        
        public string Name { get; set; }

        public int MinNumPlayers { get; set; }

        public int MaxNumPlayers { get; set; }

        public int MinMinutesToPlay { get; set; }

        public int MaxMinutesToPlay { get; set; }

        public string BoardGameGeekUrl { get; set; }

        public virtual ICollection<Person> Owners { get; set; }
    }
}
