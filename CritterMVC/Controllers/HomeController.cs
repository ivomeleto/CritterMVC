using Critter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CritterMVC.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ICritData data)
            :base(data)
        {

        }

        public ActionResult Index()
        {
            if (this.UserProfile != null)
            {
                this.ViewBag.Username = this.UserProfile.UserName;
            }

            return this.View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}