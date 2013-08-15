using BoardGameManager.Domain.Entities;

namespace BoardGameManager.Domain.Factories
{
    public class BoardGameFactory : IBoardGameFactory
    {
        public BoardGame Create(string name, int minPlayers, int maxPlayers, int? minMinutesToPlay = null, int? maxMinutesToPlay = null,
            string boardGameGeekUrl = null)
        {
            return new BoardGame(name, minPlayers, maxPlayers, minMinutesToPlay, maxMinutesToPlay, boardGameGeekUrl);
        }
    }
}