using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using crudApi.A_Application.ViewModels;
using crudApi.B_Service;
using crudApi.C_Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace crudApi.A_Application.Controllers
{
    public class PurchaseOrderController : ControllerBase
    {

        private readonly IProductService productService;
        private readonly IMapper mapper;

        public PurchaseOrderController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

   
    }
}