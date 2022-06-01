using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using crudApi.A_Application.ViewModels;
using crudApi.B_Service;
using crudApi.C_Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace crudApi.A_Application.Controllers
{
    [Route("Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }


        [HttpPost]
        public ActionResult Post( ProductVM model)
        {
            var prodTOCreate = mapper.Map<ProductVM, Product>(model);

            this.productService.Add(prodTOCreate);
            if (this.productService.SaveChanges())
            {
                return Ok(prodTOCreate);
            }
            else
            {
                return BadRequest("Product creating Error");
            }
        }

        [HttpGet]
        public ActionResult Get()
        {
            var prodList = mapper.Map<List<Product>, List<ProductVM>>(
                this.productService.GetList().ToList()
                );

            if (prodList.Count > 0)
            {
                return Ok(prodList);
            }
            else
            {
                return NotFound("Products empty list");
            }
        }

        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {

            this.productService.Delete(this.productService.GetList().Where(x => x.Id == Id).FirstOrDefault());

            if (this.productService.SaveChanges())
            {
                return Ok();
            }
            else
            {
                return BadRequest("Product not deleted");
            }
        }

        [HttpGet("{Id}")]
        public ActionResult Get(int Id)
        {

            var prodGetbyId = this.mapper.Map<Product,ProductVM>(this.productService.GetList().Where(x=>x.Id == Id).FirstOrDefault()); 
            

            if (prodGetbyId != null)
            {
                return Ok(prodGetbyId);
            }
            else
            {
                return BadRequest("Product not found");
            }
        }

        [HttpPut]
        public ActionResult Put(ProductVM productVM)
        {

            var toUpdate = this.mapper.Map<ProductVM, Product>(productVM);

            this.productService.Update(toUpdate);

            if (this.productService.SaveChanges())
            {
                return Ok(toUpdate);
            }
            else
            {
                return BadRequest("Product not updated");
            }
        }



    }
}