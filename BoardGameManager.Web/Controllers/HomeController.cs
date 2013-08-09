using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BoardGameManager.EntityFramework.DbContexts;
using BoardGameManager.EntityFramework.Entities;

namespace BoardGameManager.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            using (var boardGameContext = new BoardGameContext())
            {
                var boardGame = new BoardGame()
                {
                    Name = "Test"
                };

                boardGameContext.BoardGames.Add(boardGame);
                boardGameContext.SaveChanges();
            }

            return View();
        }

    }
}
