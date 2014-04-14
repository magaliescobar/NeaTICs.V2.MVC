using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NeaTICs_v2.Models;

namespace NeaTICs_v2.Repositories
{
    public abstract class Repository<T>
        where T : class
    {
        public Context db = new Context();

        public virtual T SearchById(int id)
        {
            T entity = db.Set<T>().Find(id);
            return (entity);
        }

        public virtual void Save(T entity)
        {
            db.SaveChanges();
        }

        public virtual void Edit(T entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            Save(entity);
        }

        public virtual void New(T entity)
        {
            db.Set<T>().Add(entity);
            Save(entity);
        }

        public virtual IEnumerable<T> ObtainList()
        {
            return db.Set<T>().ToList();
        }
    }
}