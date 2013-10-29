using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BoardGameManager.Domain.Entities
{
    public class BoardGame
    {
        public BoardGame(string name, int boardGameGeekId, GameType gameType, int minPlayers, int maxPlayers, Uri boardGameGeekReviewUri, int? minMinutesToPlay = null,
            int? maxMinutesToPlay = null)
        {
            Name = name;
            BoardGameGeekId = boardGameGeekId;
            GameType = gameType;
            MinPlayers = minPlayers;
            MaxPlayers = maxPlayers;
            boardGameGeekReviewUri = this.BoardGameGeekReviewUri;
            MinMinutesToPlay = minMinutesToPlay;
            MaxMinutesToPlay = maxMinutesToPlay;

            Owners = new Collection<Person>();
        }

        public int BoardGameId { get; set; }
        
        public string Name { get; set; }

        public int BoardGameGeekId { get; set; }

        public GameType GameType { get; set; }

        public int MinPlayers { get; set; }

        public int MaxPlayers { get; set; }

        public int? MinMinutesToPlay { get; set; }

        public int? MaxMinutesToPlay { get; set; }

        public Uri BoardGameGeekReviewUri { get; set; }

        public virtual ICollection<Person> Owners { get; set; }
    }
}
