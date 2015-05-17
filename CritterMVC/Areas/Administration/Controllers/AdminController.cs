using System.Web.Mvc;

namespace CritterMVC.Areas.Administration.Controllers
{
    public class AdminController : Controller
    {
        // GET: Administration/Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}