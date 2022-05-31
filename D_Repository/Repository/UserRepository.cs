using System.Collections.Generic;
using System.Linq;
using crudApi.C_Domain;
using crudApi.D_Repository.Interface;

namespace crudApi.D_Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext dbContext;
        public UserRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public void Add(UserData entity)
        {
            this.dbContext.users.Add(entity);
        }

        public void Delete(UserData entity)
        {
            this.dbContext.users.Remove(entity);

        }

        public ICollection<UserData> GetList()
        {
            return this.dbContext.users.ToList();
        }

        public bool SaveChanges()
        {
            return
            this.dbContext.SaveChanges() > 0;
        }

        public void Update(UserData entity)
        {
            this.dbContext.users.Update(entity);
        }
    }
}