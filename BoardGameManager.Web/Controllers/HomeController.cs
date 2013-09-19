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
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

    }
}
