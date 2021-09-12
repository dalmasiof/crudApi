using System.Collections.Generic;
using System.Linq;
using crudApi.C_Domain;
using crudApi.D_Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace crudApi.D_Repository
{
    public class UserRepository : IBaseRepository
    {
        private readonly DataContext dbContext;
        public UserRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            this.dbContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public ICollection<User> GetList() 
        {
            ICollection<User> list = this.dbContext.Users.ToList(); 
            return list;
        }

        public bool SaveChanges()
        {
            return (this.dbContext.SaveChanges()>0);
        }

        public void Update<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }
    }
}