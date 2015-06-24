using System.Web.Mvc;
using Critter.Data;
using System;
using System.Linq;
using System.Management.Instrumentation;
using System.Threading;
using Critter.Models;

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
            if (!users.Any())
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        [Route("home/AddVote/{critId}")]
        public ActionResult AddVote(int critId)
        {
            var currentCrit = this.Data.Crit.All().FirstOrDefault(x => x.CritId == critId);
            if (currentCrit == null)
            {
                throw new InstanceNotFoundException("Crit with Id "+critId+" was not found!");
            }
            if (!currentCrit.Votes.Any(x => x.User.Id == this.UserProfile.Id))
            {
                currentCrit.Votes.Add(new Vote()
                {
                    User = this.UserProfile
                });
                this.Data.Crit.Update(currentCrit);
                this.Data.SaveChanges();
            }
            var votesCount = currentCrit.Votes.Count;
            return Json(votesCount, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult Chat()
        {
            return View(UserProfile);
        }
    }
}