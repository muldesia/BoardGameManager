using BoardGameManager.EntityFramework.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BoardGameManager.EntityFramework.Entities
{
    public class BoardGame
    {
        public BoardGame(string name, int boardGameGeekId, GameType gameType, int minPlayers, int maxPlayers, string boardGameGeekReviewUri, int? minMinutesToPlay = null,
            int? maxMinutesToPlay = null) : this()
        {
            this.Name = name;
            this.BoardGameGeekId = boardGameGeekId;
            this.GameType = gameType;
            this.MinPlayers = minPlayers;
            this.MaxPlayers = maxPlayers;
            this.BoardGameGeekReviewUri = boardGameGeekReviewUri;
            this.MinMinutesToPlay = minMinutesToPlay;
            this.MaxMinutesToPlay = maxMinutesToPlay;
        }

        public BoardGame()
        {
            this.Owners = new Collection<Person>();
        }

        public int BoardGameId { get; set; }
        
        public string Name { get; set; }

        public int BoardGameGeekId { get; set; }

        public GameType GameType { get; set; }

        public int MinPlayers { get; set; }

        public int MaxPlayers { get; set; }

        public string BoardGameGeekReviewUri { get; set; }

        public int? MinMinutesToPlay { get; set; }

        public int? MaxMinutesToPlay { get; set; }

        public virtual ICollection<Person> Owners { get; set; }
    }
}
