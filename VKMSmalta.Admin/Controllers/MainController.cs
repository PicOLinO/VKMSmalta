using System.Web.Mvc;

namespace VKMSmalta.Admin.Controllers
{
    public class MainController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return
            View();
        }
    }
}