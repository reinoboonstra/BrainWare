using System.Web.Mvc;

namespace BrainShark.BrainWare.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            this.ViewBag.Title = "Home Page";

            return View();
        }
    }
}