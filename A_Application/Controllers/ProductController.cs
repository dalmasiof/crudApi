using AutoMapper;
using crudApi.B_Service;
using Microsoft.AspNetCore.Mvc;

namespace crudApi.A_Application.Controllers
{
    public class ProductController: ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }






    }
}