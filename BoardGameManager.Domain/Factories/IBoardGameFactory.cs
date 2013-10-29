using BoardGameManager.Domain.Entities;
using System;

namespace BoardGameManager.Domain.Factories
{
    public interface IBoardGameFactory
    {
        BoardGame Create(string name, int boardGameGeekId, GameType gameType, int minPlayers, int maxPlayers, Uri boardGameGeekReviewUri, int? minMinutesToPlay = null, int? maxMinutesToPlay = null);
    }
}
