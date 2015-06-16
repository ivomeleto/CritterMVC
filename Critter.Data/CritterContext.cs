using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Critter.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Critter.Data.Migrations;

namespace Critter.Data
{
    public class CritterContext : IdentityDbContext<User>, ICritterContext
    {
        public CritterContext()
            : base("CritterDb", throwIfV1Schema: false)
        {
            //TODO: Change the initializer
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CritterContext, Configuration>()); //
        }
        
        public static CritterContext Create()
        {
            return new CritterContext();
        }

        public virtual IDbSet<Crit> Crits { get; set; }
        public virtual IDbSet<Group> Groups { get; set; }
    }
}
