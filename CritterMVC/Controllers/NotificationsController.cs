using Critter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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