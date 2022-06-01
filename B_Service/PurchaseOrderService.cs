using System;
using System.Collections.Generic;
using crudApi.B_Service.Interfaces;
using crudApi.C_Domain;
using crudApi.D_Repository.Interface;

namespace crudApi.B_Service
{
    public class PurchaseOrderService : IPurchaseOrderService
    {

        private readonly IPurchaseOrderRepository repository;

        public PurchaseOrderService(IPurchaseOrderRepository repository)
        {
            this.repository = repository;

        }
        public void Add(PurchaseOrder entity)
        {
            this.repository.Add(entity);
        }

        public void Delete(PurchaseOrder entity)
        {
            this.repository.Delete(entity);
        }

        public ICollection<PurchaseOrder> GetList()
        {
            return this.repository.GetList();
        }

        public bool SaveChanges()
        {
            return this.repository.SaveChanges();
        }

        public void Update(PurchaseOrder entity)
        {
            this.repository.Update(entity);
        }
    }
}
