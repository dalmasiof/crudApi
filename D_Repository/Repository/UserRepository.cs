using System.Collections.Generic;
using System.Linq;
using crudApi.C_Domain;
using crudApi.D_Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace crudApi.D_Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext dbContext;
        public ProductRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Product entity)
        {
            try
            {
                this.dbContext.products.Add(entity);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(Product entity)
        {
            try
            {
                this.dbContext.products.Remove(entity);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public ICollection<Product> GetList()
        {
            try
            {
                return this.dbContext.products.ToList();

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

        public void Update(Product entity)
        {
            try
            {
                this.dbContext.products.Update(entity);

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}