using System.Linq;
using System.Web.Mvc;
using Critter.Data;
using CritterMVC.ViewModels;

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
               .All();


            if (crits == null)
            {
                return this.HttpNotFound("User does not exist! For real!");
            }

            var critViewModel = crits.AsQueryable();
            return this.View();
        }
    }
}