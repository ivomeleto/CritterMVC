using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Web.Mvc;
using Critter.Data;
using CritterMVC.ViewModels;
using Critter.Models;
using System.Web.Routing;
using System.Threading;
using Microsoft.Ajax.Utilities;

namespace CritterMVC.Controllers
{
    [Authorize]
    public class UsersController : BaseController
    {
        public UsersController(ICritData data)
            :base(data)
        {
        }

        //public ActionResult NoUserLogged()
        //{
        //    return RedirectToAction("Login", "Account");
        //}
        [Route("users/info/{username}")]
        public ActionResult Info(string username)
        {
            var user = this.Data
                .Users
                .All()
                .FirstOrDefault(x => x.UserName == username);

            ViewBag.LoggedUser = this.UserProfile.UserName;

            var userViewModel = new UserViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                AvatarUrl = user.AvatarUrl,
                Email = user.Email,
                PostedCrits = user
                    .PostedCrits
                    .Select(x => CritViewModel.ToViewModel(x))
            };
            
            return this.View(userViewModel);          
        }
        [Route("users/addfriend/{friendName}")]
        public ActionResult AddFriend(string friendName)
        {
            var currentUser = this.UserProfile;
            var friend = this.Data
                .Users
                .All()
                .FirstOrDefault(x => x.UserName == friendName);

            if (friend == null)
            {
                throw new InstanceNotFoundException(
                    "Sorry "+currentUser.UserName+", your friend "+friendName+" was not found!");
            }

            if (!currentUser.Friends.Any(x => x.UserName == friendName))
            {
                currentUser.Friends.Add(friend);
                this.Data.Users.Update(currentUser);
            }

            //throw new InstanceNotFoundException(currentUser.Friends.Count.ToString());

            return RedirectToAction("SeeFriends", "Users", new {id = currentUser.UserName});
        }

        [Route("users/removefriend/{friendName}")]
        public ActionResult RemoveFriend(string friendName)
        {
            var currentUser = this.UserProfile;
            var friend = this.Data
                .Users
                .All()
                .FirstOrDefault(x => x.UserName == friendName);

            if (friend == null)
            {
                throw new InstanceNotFoundException(
                    "Sorry " + currentUser.UserName + ", your friend " + friendName + " was not found!");
            }

            currentUser.Friends.Remove(friend);
            this.Data.Users.Update(currentUser);

            //throw new InstanceNotFoundException(currentUser.Friends.Count.ToString());

            return RedirectToAction("SeeFriends", "Users", new { id = currentUser.UserName });
        }

        [Route("users/seefriends/{friendName}")]
        public ActionResult SeeFriends(string username)
        {
            var currentUser = this.UserProfile;
            return this.View(currentUser.Friends);
        }

     
    }
}