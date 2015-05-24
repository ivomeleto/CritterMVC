using System.Web.Mvc;
using Critter.Data;
using System;
using System.Threading;

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

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }

        public ActionResult ServerTime()
        {
            Thread.Sleep(1000);
            
            return this.Content("<div>Holy shit </div>");
        }

        public ActionResult AjaxTest()
        {
            return this.View();
        }
    }
}