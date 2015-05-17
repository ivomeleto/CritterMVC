using System.Web.Mvc;
using Critter.Data;

namespace CritterMVC.Controllers
{
    public class NotificationsController : BaseController
    {
        public NotificationsController(ICritData data)
            :base(data)
        {

        }
        // GET: Notification
        public ActionResult Index()
        {
            return View();
        }
    }
}