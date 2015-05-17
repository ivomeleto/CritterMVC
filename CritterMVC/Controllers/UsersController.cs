using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Critter.Data;
using CritterMVC.ViewModels;
using Critter.Models;

namespace CritterMVC.Controllers
{
    [Authorize]
    public class UsersController : BaseController
    {
        public UsersController(ICritData data)
            :base(data)
        {
        }

        public ActionResult Index(string username)
        {
            var user = this.Data.Users
                .GetAll()
                .FirstOrDefault(x => x.UserName == username);

            //TODO db realations one-to-many/many-to-many for crits and users needs to be fixed

            if (user == null)
            {
                return this.HttpNotFound("User does not exist! For real!");
            }

            var userViewModel = new UserViewModel().FromModel(user);
            
            return this.View(userViewModel);
        }
    }
}