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

        public void Add(UserFake entity)
        {
            try
            {
                this.dbContext.UserFakes.Add(entity);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(UserFake entity)
        {
            try
            {
                this.dbContext.UserFakes.Remove(entity);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public ICollection<UserFake> GetList()
        {
            try
            {
                return this.dbContext.UserFakes.ToList();

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

        public void Update(UserFake entity)
        {
            try
            {
                this.dbContext.UserFakes.Update(entity);

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}