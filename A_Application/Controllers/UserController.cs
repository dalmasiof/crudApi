using crudApi.C_Domain;
using crudApi.D_Repository;
using crudApi.D_Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace crudApi.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly IBaseRepository repository;

        public UserController(IBaseRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(this.repository.GetList());
        }

        [HttpPost]
        public ActionResult Post()
        {
            var mockUser = new User(){
                Cpf="484956288",
                ConfirmPassword="minhaSenha",
                Email="dalmasiof@gmail.com",
                Name="Dalmasio",
                PassWord="minhaSenha",
                Phone="11963406824"
            };

            this.repository.Add(mockUser);
            this.repository.SaveChanges();
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