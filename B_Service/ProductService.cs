using System.Collections.Generic;
using crudApi.C_Domain;
using crudApi.D_Repository.Interface;

namespace crudApi.B_Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;

        }
        public void Add(Product entity)
        {
            this.repository.Add(entity);
        }

        public void Delete(Product entity)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Product> GetList()
        {
            return this.repository.GetList();
        }

        public bool SaveChanges()
        {
            return this.repository.SaveChanges();
        }

        public void Update(Product entity)
        {
            throw new System.NotImplementedException();
        }
    }
}