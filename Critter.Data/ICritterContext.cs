using Critter.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Critter.Data
{
    public interface ICritterContext
    {
        IDbSet<Crit> Crits { get; set; }

        int SaveChanges();
    }
}
