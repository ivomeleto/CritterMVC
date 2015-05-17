using System.Web.Mvc;
using Critter.Data;

namespace CritterMVC.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController(ICritData data)
            :base(data)
        {
        }

        public ActionResult Index(string username)
        {
            return this.View();
        }
    }
}