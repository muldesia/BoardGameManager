using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Helpers;
using System.Web.Mvc;
using BoardGameManager.Domain.Repositories;
using BoardGameManager.Web.ViewModels;

namespace BoardGameManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBoardGameRepository _boardGameRepositroy;
        
        public HomeController(IBoardGameRepository boardGameRepositroy)
        {
            _boardGameRepositroy = boardGameRepositroy;
        }

        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Home/BoardGameList
        public JsonResult BoardGameList()
        {
            var boardGames = _boardGameRepositroy.ListAll();

            var viewModel = boardGames.Select(x => new BoardGameIdAndNameViewModel(x.BoardGameId, x.Name));
            
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

    }
}
