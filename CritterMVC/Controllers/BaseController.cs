using Critter.Data;
using Critter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CritterMVC.Controllers
{
    public abstract class BaseController : Controller
    {
        private ICritData data;
        private User userProfile;  //possible performance problem (in a larger app)
        protected BaseController(ICritData data)
        {
            this.Data = data;
        }

        protected BaseController(ICritData data, User userProfile)
            :this(data)
        {
            this.UserProfile = userProfile;
        }

        protected ICritData Data { get; private set; }
        protected User UserProfile { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var userName = requestContext.HttpContext.User.Identity.Name; // the logged users' name (taken from context)
                var user = this.Data.Users.GetAll().FirstOrDefault(x => x.UserName == userName);
                this.UserProfile = user;
            }
            return base.BeginExecute(requestContext, callback, state);
        }
    }
}