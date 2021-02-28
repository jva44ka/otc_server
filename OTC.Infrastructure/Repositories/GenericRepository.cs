using Microsoft.EntityFrameworkCore;
using OTC.Domain.Interfaces;
using System;
using System.Linq;

namespace OTC.Infrastructure.Repositories
{
    public class GenericRepository<T> : IRepository<T> 
        where T : class, IDataModel
    {
        protected readonly DbMainContext _context;
        protected DbSet<T> DbEntities { get; }

        public GenericRepository(DbMainContext context)
        {
            _context = context;
            DbEntities = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return DbEntities;
        }

        public T GetById(Guid id)
        {
            return DbEntities.Find(id);
        }

        public T Create(T model)
        {
            return DbEntities.Add(model).Entity;
        }

        public T Update(T model)
        {
            var result = DbEntities.Update(model).Entity;
            _context.Entry(model).State = EntityState.Modified;
            return result;
        }

        public T Delete(Guid id)
        {
            var entity = DbEntities.Find(id);
            return DbEntities.Remove(entity).Entity;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
