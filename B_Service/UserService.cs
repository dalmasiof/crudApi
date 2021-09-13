using System.Collections.Generic;
using crudApi.C_Domain;
using crudApi.D_Repository.Interface;

namespace crudApi.B_Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;

        }
        public void Add(UserFake entity)
        {
            this.repository.Add(entity);
        }

        public void Delete(UserFake entity)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<UserFake> GetList()
        {
            return this.repository.GetList();
        }

        public bool SaveChanges()
        {
            return this.repository.SaveChanges();
        }

        public void Update(UserFake entity)
        {
            throw new System.NotImplementedException();
        }
    }
}