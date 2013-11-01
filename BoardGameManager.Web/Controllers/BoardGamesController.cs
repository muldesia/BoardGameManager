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
        private readonly IBoardGameImageFetchService _boardGameImageFetchService;
        private readonly IBoardGameImageCacheService _boardGameImageCacheService;

        public BoardGamesController(IBoardGameRepository boardGameRepositroy, IBoardGameImageFetchService boardGameImageFetchService, IBoardGameImageCacheService boardGameImageCacheService)
        {
            _boardGameRepositroy = boardGameRepositroy;
            _boardGameImageFetchService = boardGameImageFetchService;
            _boardGameImageCacheService = boardGameImageCacheService;
        }

        //
        // GET: api/BoardGames
        public HttpResponseMessage GetAll()
        {
            var boardGames = _boardGameRepositroy.ListAll();

            var boardGameViewModels = Mapper.Map<ICollection<BoardGameViewModel>>(boardGames);

            Parallel.ForEach(boardGameViewModels, boardGameViewModel =>
            {
                BoardGameImages boardGameImages;
                if (!_boardGameImageCacheService.TryGetBoardGameImages(boardGameViewModel.BoardGameGeekReviewUri, out boardGameImages))
                {
                    boardGameImages = _boardGameImageFetchService.GetBoardGameImages(boardGameViewModel.BoardGameGeekReviewUri);
                    _boardGameImageCacheService.AddBoardGameImagesToCache(boardGameViewModel.BoardGameGeekReviewUri, boardGameImages);
                }

                boardGameViewModel.BoardGameGeekSmallImageUri = boardGameImages.SmallBoardGameImage;
                boardGameViewModel.BoardGameGeekMediumImageUri = boardGameImages.MediumBoardGameImage;
            });

            var orderedBoardGameViewModels = boardGameViewModels.OrderBy(x => x.Name);

            return Request.CreateResponse<IEnumerable<BoardGameViewModel>>(HttpStatusCode.OK, orderedBoardGameViewModels);
        }
    }
}
