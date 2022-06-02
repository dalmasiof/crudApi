using System;
using System.Collections.Generic;

namespace crudApi.A_Application.ViewModels
{
    public class PurchaseOrderVM
    {
        public int IdUserata { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public decimal TotalToPay { get; set; }
        public string StatusDelivery { get; set; }
        public string StatusPO { get; set; }
        public ICollection<ProductVM> Products { get; set; }
    }
}
