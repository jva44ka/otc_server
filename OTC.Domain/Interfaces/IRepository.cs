using System;
using System.Linq;

namespace OTC.Domain.Interfaces
{
    public interface IRepository<T> where T : class, IDataModel
    {
        IQueryable<T> GetAll();
        T GetById(Guid id);
        T Create(T model);
        T Update(T model);
        T Delete(Guid id);
        void SaveChanges();
    }
}
