using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CritterMVC.Controllers
{
    public class NotificationsController : BaseController
    {
        // GET: Notification
        public ActionResult Index()
        {
            return View();
        }
    }
}