using System.Collections.Generic;
using crudApi.C_Domain;

namespace crudApi.D_Repository.Interface
{
    public interface IBaseRepository <T> 
    {
        
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        ICollection<T> GetList();
        bool SaveChanges();





    }
}