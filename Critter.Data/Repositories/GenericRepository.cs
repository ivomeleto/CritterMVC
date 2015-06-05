using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Critter.Data.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        protected readonly DbContext dbContext;
        protected IDbSet<T> DbSet { get; set; }

        public GenericRepository(DbContext context)
        {
            this.dbContext = context;
            this.DbSet = this.dbContext.Set<T>();
        }


        public GenericRepository()
        {
            this.dbContext = new CritterContext();
        }

        public IQueryable<T> All()
        {
            return this.DbSet;
        }

        public T GetById(object id)
        {
            var entity = this.DbSet.Find(id);
            return entity;
        }

        public void Add(T item)
        {
            this.DbSet.Add(item);
            SaveChanges();
        }

        public void Update(T item)
        {
            DbEntityEntry entry = this.dbContext.Entry(item);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(item);
            }

            entry.State = EntityState.Modified;
            SaveChanges();
        }

        public void DeleteById(object id)
        {
            var entity = this.GetById(id);
            Delete(entity);
        }

        public void Delete(T item)
        {
            DbEntityEntry entry = this.dbContext.Entry(item);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
                this.DbSet.Remove(item);
                //Console.WriteLine(item.ToString());
                SaveChanges();
            }

        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }
    }
}
