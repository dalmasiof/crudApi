using System.Collections.Generic;
using crudApi.C_Domain;

namespace crudApi.D_Repository.Interface
{
    public interface IBaseRepository
    {
        
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        ICollection<User> GetList();

        bool SaveChanges();





    }
}