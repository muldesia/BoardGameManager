using BoardGameManager.Domain.Entities;

namespace BoardGameManager.Domain.Factories
{
    public interface IBoardGameFactory
    {
        BoardGame Create(string name, int minPlayers, int maxPlayers, int? minMinutesToPlay = null,
            int? maxMinutesToPlay = null, string boardGameGeekUrl = null);
    }
}
