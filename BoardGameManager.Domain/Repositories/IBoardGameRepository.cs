using System.Collections.Generic;
using System.Linq;
using BoardGameManager.Domain.Entities;

namespace BoardGameManager.Domain.Repositories
{
    public interface IBoardGameRepository
    {
        ICollection<BoardGame> ListAll();
    }
}
