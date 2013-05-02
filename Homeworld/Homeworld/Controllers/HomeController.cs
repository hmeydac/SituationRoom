namespace Homeworld.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Concept()
        {
            return this.View();
        }
    }
}
