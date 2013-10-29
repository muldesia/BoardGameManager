using BoardGameManager.Domain.Entities;
using System;

namespace BoardGameManager.Domain.Factories
{
    public class BoardGameFactory : IBoardGameFactory
    {
        public BoardGame Create(string name, int boardGameGeekId, GameType gameType, int minPlayers, int maxPlayers, Uri boardGameGeekReviewUri, int? minMinutesToPlay = null, int? maxMinutesToPlay = null)
        {
            return new BoardGame(name, boardGameGeekId, gameType, minPlayers, maxPlayers, boardGameGeekReviewUri, minMinutesToPlay, maxMinutesToPlay);
        }
    }
}