using System;
using System.Linq;
using System.Management.Instrumentation;
using System.Web.Mvc;
using System.Web.Routing;
using Critter.Data;
using Critter.Models;

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
                var user = this.Data.Users.All().FirstOrDefault(x => x.UserName == userName);
                this.UserProfile = user;
            }
            if (this.UserProfile == null)
            {
                //throw new InstanceNotFoundException("shit");
                return base.BeginExecute(requestContext, callback, state);
            }
            return base.BeginExecute(requestContext, callback, state);
        }
    }
}