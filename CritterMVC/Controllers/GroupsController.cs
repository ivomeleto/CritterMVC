using Critter.Data;
using Critter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Web;
using System.Web.Mvc;
using CritterMVC.ViewModels;

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
            var groups = this.Data.Group
                .All()
                .Select(GroupViewModel.ViewModel);

            return View(groups);
        }

        [HttpGet]
        [Authorize]
        public ActionResult GroupDetails(int? id)
        {
            var group = this.Data.Group
                .All()
                .Select(GroupViewModel.ViewModel)
                .FirstOrDefault(x => x.Id == id);
            ViewBag.CurrentUser = this.UserProfile.UserName;

            return View(group);
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
            return RedirectToAction("Index", "Groups");
        }

        [Authorize]
        public ActionResult JoinGroup(int? id)
        {

            var currentUser = this.UserProfile;
            var groups = this.Data.Group.All();
            var group = groups
                .FirstOrDefault(x => x.GroupId == id);

            try
            {
                group.Users.Add(currentUser);
            }
            catch (NullReferenceException exception)
            {
                throw new InstanceNotFoundException(exception.ToString());
            }

            this.Data.Group.Update(group);
            this.Data.Group.SaveChanges();

            var groupViewModel = groups
                .Select(GroupViewModel.ViewModel)
                .FirstOrDefault(x => x.Id == id);

            ViewBag.CurrentUser = currentUser.UserName;

            return this.View("GroupDetails", groupViewModel);
        }

        [Authorize]
        public ActionResult LeaveGroup(int? id)
        {

            var currentUser = this.UserProfile;
            var groups = this.Data.Group.All();
            var group = groups
                .FirstOrDefault(x => x.GroupId == id);

            try
            {
                group.Users.Remove(currentUser);
            }
            catch (NullReferenceException exception)
            {
                throw new InstanceNotFoundException(exception.ToString());
            }

            this.Data.Group.Update(group);
            this.Data.Group.SaveChanges();

            var groupViewModel = groups
                .Select(GroupViewModel.ViewModel)
                .FirstOrDefault(x => x.Id == id);

            ViewBag.CurrentUser = currentUser.UserName;

            return this.View("GroupDetails", groupViewModel);
        }
    }
}