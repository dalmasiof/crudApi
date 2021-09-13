using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace crudApi.A_Application.Controllers
{
    public class CartController : ControllerBase
    {
        //  private readonly IProductService productService;
        private readonly IMapper mapper;

        public CartController(IMapper mapper)
        {
            this.mapper = mapper;
        }
    }
}