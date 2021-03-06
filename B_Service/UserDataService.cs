using System.Collections.Generic;
using crudApi.D_Repository.Interface;

namespace crudApi.B_Service.Interfaces
{
    public class UserDataService : IUserService
    {
        private readonly IUserRepository repository;

        public UserDataService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public void Add(C_Domain.UserData entity)
        {
            repository.Add(entity);
        }

        public void Delete(C_Domain.UserData entity)
        {
            repository.Delete(entity);

        }

        public ICollection<C_Domain.UserData> GetList()
        {
            return repository.GetList();
        }

        public bool SaveChanges()
        {
            return this.repository.SaveChanges();

        }

        public void Update(C_Domain.UserData entity)
        {
            this.repository.Update(entity);
        }
    }
}