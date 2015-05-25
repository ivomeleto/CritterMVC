using System.Web.Mvc;
using Critter.Data;
using System;
using System.Linq;
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

        public ActionResult IsNameTaken(string username)
        {
            Thread.Sleep(1000);
            var users = this.Data.Users.All().Where(x => x.UserName == username);
            if (users.Count() == 0)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
    }
}