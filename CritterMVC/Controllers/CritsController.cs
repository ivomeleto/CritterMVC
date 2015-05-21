using System;
using System.Linq;
using System.Web.Mvc;
using Critter.Data;
using CritterMVC.ViewModels;
using Critter.Models;

namespace CritterMVC.Controllers
{
    public class CritsController : BaseController
    {
        public CritsController(ICritData data)
            : base(data)
        {

        }
        // GET: Crits
        public ActionResult Index()
        {
            var crits = this.Data.Crit
                .All().Select(x => new CritViewModel()
                    {
                        Id = x.CritId,
                        Author = x.AuthorUser,
                        Text = x.Text,
                        CreatedAt = x.CreatedAt
                    }
                );


            if (crits == null)
            {
                return this.HttpNotFound("User does not exist! For real!");
            }

            var critViewModel = crits.AsQueryable();
            return this.View(crits);
        }

        public ActionResult AddCrit()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCrit([Bind(Include = "Text")] Crit crit)
        {
            crit.AuthorUser = this.UserProfile;
            if (crit.AuthorUser == null)
            {
                //TODO redirect to login page
            }
            crit.CreatedAt = DateTime.Now;
            if (ModelState.IsValid)
            {
                this.Data.Crit.Add(crit);
                this.Data.Crit.SaveChanges();
            }
            return this.View(crit);
        }
    }
}