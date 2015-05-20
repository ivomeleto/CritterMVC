using Critter.Data.Repositories;
using Critter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Critter.Data
{
    public interface ICritData
    {
        IRepository<User> Users { get; }
        IRepository<Crit> Crit { get; }

        int SaveChanges();
    }
}
