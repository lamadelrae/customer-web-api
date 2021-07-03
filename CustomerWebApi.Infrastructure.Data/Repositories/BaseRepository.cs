using CustomerWebApi.Domain.Models;
using CustomerWebApi.Infrastructure.Data.Database;
using CustomerWebApi.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerWebApi.Infrastructure.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        protected readonly Context _context = new Context();

        public virtual void Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
            _context.SaveChanges();
        }

        public virtual List<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T Get(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual void Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        public virtual void Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
