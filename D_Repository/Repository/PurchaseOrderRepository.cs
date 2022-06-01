using System;
using System.Collections.Generic;
using System.Linq;
using crudApi.C_Domain;
using crudApi.D_Repository.Interface;

namespace crudApi.D_Repository.Repository
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly DataContext dbContext;
        public PurchaseOrderRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(PurchaseOrder entity)
        {
            try
            {
                this.dbContext.purchaseOrders.Add(entity);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(PurchaseOrder entity)
        {
            try
            {
                this.dbContext.purchaseOrders.Remove(entity);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public ICollection<PurchaseOrder> GetList()
        {
            try
            {
                return this.dbContext.purchaseOrders.ToList();

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

        public void Update(PurchaseOrder entity)
        {
            try
            {
                this.dbContext.purchaseOrders.Update(entity);

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
