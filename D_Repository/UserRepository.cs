using System.Collections.Generic;
using System.Linq;
using crudApi.C_Domain;
using crudApi.D_Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace crudApi.D_Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext dbContext;
        public UserRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(User entity)
        {
            try
            {
                this.dbContext.Users.Add(entity);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(User entity)
        {
            try
            {
                this.dbContext.Users.Remove(entity);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public ICollection<User> GetList()
        {
            try
            {
                return this.dbContext.Users.ToList();

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public bool SaveChanges()
        {
            try
            {
                return (this.dbContext.SaveChanges() > 0);

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Update(User entity)
        {
            try
            {
                this.dbContext.Users.Update(entity);

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}