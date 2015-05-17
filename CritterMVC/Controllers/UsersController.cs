using Critter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CritterMVC.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController(ICritData data)
            :base(data)
        {
        }

        //public ActionResult Index(string username)
        //{
        //    return this.View();
        //}
    }
}