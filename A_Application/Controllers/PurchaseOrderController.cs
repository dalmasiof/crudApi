using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using crudApi.A_Application.ViewModels;
using crudApi.B_Service;
using crudApi.B_Service.Interfaces;
using crudApi.C_Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace crudApi.A_Application.Controllers
{
    [Route("PurchaseOrder")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {

        private readonly IPurchaseOrderService purchaseOrderService;
        private readonly IMapper mapper;

        public PurchaseOrderController(IPurchaseOrderService purchaseOrderService, IMapper mapper)
        {
            this.purchaseOrderService = purchaseOrderService;
            this.mapper = mapper;
        }



        [HttpGet]
        public ActionResult Get()
        {
            var poList = mapper.Map<ICollection<PurchaseOrder>, ICollection<PurchaseOrderVM>>(
                this.purchaseOrderService.GetList()
                );

            if (poList.Count > 0)
            {
                return Ok(poList);
            }
            else
            {
                return NotFound("PO`s empty list");
            }
        }

        [HttpPost]
        public ActionResult Post(PurchaseOrderVM model)
        {
            var PObd = this.mapper.Map<PurchaseOrderVM, PurchaseOrder>(model);
            this.purchaseOrderService.Add(PObd);
            if (this.purchaseOrderService.SaveChanges())
                return Ok(model);

            return BadRequest();
        }

        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {

            this.purchaseOrderService.Delete(this.purchaseOrderService.GetList().Where(x => x.Id == Id).FirstOrDefault());

            if (this.purchaseOrderService.SaveChanges())
            {
                return Ok();
            }
            else
            {
                return BadRequest("PO not deleted");
            }
        }

        [HttpGet]
        [Route("GetById/{Id}")]
        public ActionResult Get(int Id)
        {

            var poGetbyId = this.mapper.Map<PurchaseOrder, PurchaseOrderVM>(this.purchaseOrderService.GetList().Where(x => x.Id == Id).FirstOrDefault());


            if (poGetbyId != null)
            {
                return Ok(poGetbyId);
            }
            else
            {
                return BadRequest("POs not found");
            }
        }

        [HttpGet("{Id}")]
        [Route("GetPosCli/{Id}")]
        public ActionResult GetByUserId(int Id)
        {

            var poGetbyUserId = this.mapper.Map<IEnumerable<PurchaseOrder>, IEnumerable<PurchaseOrderVM>>(this.purchaseOrderService.GetList().Where(x => x.IdUserata == Id).OrderByDescending(x => x.Id));


            if (poGetbyUserId.Any())
            {
                return Ok(poGetbyUserId);
            }
            else
            {
                return Ok();
            }
        }

        [HttpPut]
        public ActionResult Put(PurchaseOrderVM poVM)
        {

            var toUpdate = this.mapper.Map<PurchaseOrderVM, PurchaseOrder>(poVM);

            this.purchaseOrderService.Update(toUpdate);


            if (this.purchaseOrderService.SaveChanges())
            {
                var toUpdateVM = this.mapper.Map<PurchaseOrder, PurchaseOrderVM>(toUpdate);
                return Ok(toUpdateVM);
            }
            else
            {
                return BadRequest("PO not updated");
            }
        }



    }
}