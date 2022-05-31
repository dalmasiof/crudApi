using System.Collections.Generic;

namespace crudApi.C_Domain
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string ImgPath { get; set; }

        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}