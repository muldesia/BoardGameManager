using BoardGameManager.Domain.Repositories;
using BoardGameManager.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BoardGameManager.Web.Controllers
{
    public class BoardGamesController : ApiController
    {
        private readonly IBoardGameRepository _boardGameRepositroy;

        public BoardGamesController(IBoardGameRepository boardGameRepositroy)
        {
            _boardGameRepositroy = boardGameRepositroy;
        }

        //
        // GET: api/BoardGames
        public HttpResponseMessage GetAll()
        {
            var boardGames = _boardGameRepositroy.ListAll();

            var viewModel = boardGames.Select(x => new BoardGameIdAndNameViewModel(x.BoardGameId, x.Name));

            //var viewModel = new BoardGameIdAndNameViewModel(1, "Test");

            return Request.CreateResponse<IEnumerable<BoardGameIdAndNameViewModel>>(HttpStatusCode.OK, viewModel);
        }
    }
}
