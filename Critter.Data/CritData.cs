using Critter.Data.Repositories;
using Critter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Critter.Data
{
    public class CritData : ICritData
    {
        private ICritterContext context;
        private IDictionary<Type, object> repositories;

        public CritData(CritterContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }
    
        public IRepository<Crit> Crit
        {
            get { return this.GetRepository<Crit>(); }
        }

        private IRepository<T> GetRepository<T>() where T: class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);
                var repository = Activator.CreateInstance(typeOfRepository, this.context);
                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }

        public int SaveChanges()
        {
 	        return this.context.SaveChanges();
        }
    }
}
