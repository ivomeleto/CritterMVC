using Critter.Data;
using Critter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CritterMVC.Controllers
{
    public class GroupsController : BaseController
    {
         public GroupsController(ICritData data)
            : base(data)
        {

        }
        // GET: Groups
        public ActionResult Index()
        {
            //TODO
            return View();
        }

        
        public ActionResult CreateGroup()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGroup([Bind(Include = "Description, Name")] Group group)
        {
            group.AuthorUser = this.UserProfile;
            if (ModelState.IsValid)
            {
                this.Data.Group.Add(group);
                this.Data.Group.SaveChanges();
            }
            return this.View();
        }
    }
}