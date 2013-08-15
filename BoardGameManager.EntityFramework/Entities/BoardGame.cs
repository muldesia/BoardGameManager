﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Policy;

namespace BoardGameManager.EntityFramework.Entities
{
    public class BoardGame
    {
        public BoardGame(string name, int minPlayers, int maxPlayers, int? minMinutesToPlay = null,
            int? maxMinutesToPlay = null, string boardGameGeekUrl = null) : this()
        {
            this.Name = name;
            this.MinPlayers = minPlayers;
            this.MaxPlayers = maxPlayers;
            this.MinMinutesToPlay = minMinutesToPlay;
            this.MaxMinutesToPlay = maxMinutesToPlay;
            this.BoardGameGeekUrl = boardGameGeekUrl;
        }

        public BoardGame()
        {
            this.Owners = new Collection<Person>();
        }

        public int BoardGameId { get; set; }
        
        public string Name { get; set; }

        public int MinPlayers { get; set; }

        public int MaxPlayers { get; set; }

        public int? MinMinutesToPlay { get; set; }

        public int? MaxMinutesToPlay { get; set; }

        public string BoardGameGeekUrl { get; set; }

        public virtual ICollection<Person> Owners { get; set; }
    }
}