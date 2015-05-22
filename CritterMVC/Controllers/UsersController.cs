using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Critter.Data;
using CritterMVC.ViewModels;
using Critter.Models;
using System.Web.Routing;

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

        public ActionResult Index(string username)
        {

            var user = this.Data.Users
                .All()
                .FirstOrDefault(x => x.UserName == username);


            if (user == null)
            {   
                
                return RedirectToAction("Index", "Home");
            }

            var userViewModel = new UserViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                AvatarUrl = user.AvatarUrl,
                PostedCrits = user
                    .PostedCrits
                    .Select(x => CritViewModel.ToViewModel(x))
            };
            
            return this.View(userViewModel);

            
        }
    }
}