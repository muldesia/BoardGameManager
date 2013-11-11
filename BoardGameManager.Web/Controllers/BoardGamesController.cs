using AutoMapper;
using BoardGameManager.Application.Services;
using BoardGameManager.Domain.Repositories;
using BoardGameManager.Domain.Services;
using BoardGameManager.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace BoardGameManager.Web.Controllers
{
    public class BoardGamesController : ApiController
    {
        private readonly IBoardGameRepository _boardGameRepositroy;
        private readonly IBoardGameGeekInfoService _boardGameGeekInfoService;
        private readonly IBoardGameGeekInfoCacheService _boardGameGeekInfoCacheService;

        public BoardGamesController(IBoardGameRepository boardGameRepositroy, IBoardGameGeekInfoService boardGameGeekInfoService, IBoardGameGeekInfoCacheService boardGameGeekInfoCacheService)
        {
            _boardGameRepositroy = boardGameRepositroy;
            _boardGameGeekInfoService = boardGameGeekInfoService;
            _boardGameGeekInfoCacheService = boardGameGeekInfoCacheService;
        }

        //
        // GET: api/BoardGames
        public HttpResponseMessage GetAll()
        {
            var boardGames = _boardGameRepositroy.ListAll();

            var boardGameViewModels = Mapper.Map<ICollection<BoardGameViewModel>>(boardGames);

            Parallel.ForEach(boardGameViewModels, boardGameViewModel =>
            {
                BoardGameGeekGameDetails boardGameGeekGameDetails;
                if (!_boardGameGeekInfoCacheService.TryGetBoardGameImages(boardGameViewModel.BoardGameGeekReviewUri, out boardGameGeekGameDetails))
                {
                    boardGameGeekGameDetails = _boardGameGeekInfoService.GetBoardGameDetails(boardGameViewModel.BoardGameGeekReviewUri);
                    _boardGameGeekInfoCacheService.AddBoardGameImagesToCache(boardGameViewModel.BoardGameGeekReviewUri, boardGameGeekGameDetails);
                }

                boardGameViewModel.BoardGameGeekSmallImageUri = boardGameGeekGameDetails.SmallBoardGameImage;
                boardGameViewModel.BoardGameGeekMediumImageUri = boardGameGeekGameDetails.MediumBoardGameImage;
                boardGameViewModel.BoardGameGeekDescription = boardGameGeekGameDetails.Description;
            });

            var orderedBoardGameViewModels = boardGameViewModels.OrderBy(x => x.Name);

            return Request.CreateResponse<IEnumerable<BoardGameViewModel>>(HttpStatusCode.OK, orderedBoardGameViewModels);
        }
    }
}
