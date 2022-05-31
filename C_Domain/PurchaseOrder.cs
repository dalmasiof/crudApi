using System.Collections.Generic;

namespace crudApi.C_Domain
{
    public class PurchaseOrder : BaseEntity
    {
        public int IdUserata { get; set; }
        public int IdProduct { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public decimal TotalToPay { get; set; }
        public string StatusDelivery { get; set; }
        public string StatusPO { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}