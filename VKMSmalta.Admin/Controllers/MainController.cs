using System.Web.Mvc;
using VKMSmalta.Admin.Services;

namespace VKMSmalta.Admin.Controllers
{
    public class MainController : Controller
    {
        private readonly MainRepository mainRepository = new MainRepository();

        // GET
        public ActionResult Index()
        {
            ViewData.Add("teams", mainRepository.GetTeams());

            return View("MainPage");
        }
    }
}