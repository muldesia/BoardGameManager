using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BoardGameManager.Domain.Entities;
using BoardGameManager.EntityFramework;
using BoardGameManager.EntityFramework.DbContexts;

namespace BoardGameManager.Domain.Repositories
{
    public class BoardGameRepository : IBoardGameRepository
    {
        private readonly IBoardGameDbContext _boardGameDbContext;

        public BoardGameRepository(IUnitOfWork unitOfWork)
        {
            _boardGameDbContext = unitOfWork.Context as IBoardGameDbContext;
        }

        public ICollection<BoardGame> ListAll()
        {
            var listOfBoardGameDbEntities = _boardGameDbContext.BoardGames.ToList();
            Mapper.CreateMap<EntityFramework.Entities.BoardGame, BoardGame>();
            return Mapper.Map<ICollection<BoardGame>>(listOfBoardGameDbEntities);
        }
    }
}