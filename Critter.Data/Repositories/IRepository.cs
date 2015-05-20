using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Critter.Data.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> All();
        T GetById(object id);
        void Add(T item);
        void Update(int id, T item);
        void Delete(T item);
        void DeleteById(object id);
        void SaveChanges();
    }
}
