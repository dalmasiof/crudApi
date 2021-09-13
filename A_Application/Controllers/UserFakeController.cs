using AutoMapper;
using crudApi.A_Application.ViewModels;
using crudApi.B_Service;
using crudApi.C_Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace crudApi.Controllers
{
    [ApiController]
    [Route("UserFake")]
    public class UserFakeController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserService service;


        public UserFakeController(IUserService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;

        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(this.service.GetList());
        }

        [Authorize]
        [HttpPost]
        public ActionResult Post()
        {
            var mockUser = new UserVM()
            {
                Cpf = "484956288",
                ConfirmPassword = "minhaSenha",
                Email = "dalmasiof@gmail.com",
                Name = "Dalmasio",
                PassWord = "minhaSenha",
                Phone = "11963406824"
            };

            var toCreate = this.mapper.Map<UserVM, UserFake>(mockUser);


            this.service.Add(toCreate);
            this.service.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return Ok("foi");
        }

        [HttpPut]
        public ActionResult Put()
        {
            return Ok("foi");
        }
    }
}