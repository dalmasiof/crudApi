
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using crudApi.A_Application.ViewModels;
using crudApi.B_Service;
using crudApi.C_Domain;
using Microsoft.AspNetCore.Mvc;


namespace crudApi.A_Application.Controllers
{
    [Route("User")]
    [ApiController]

    // [AllowAn]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userSvc;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userSvc = userService;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("Create")]
        public ActionResult Create(UserDataVM model)
        {

            var userBD = this._mapper.Map<UserDataVM, UserData>(model);
            this._userSvc.Add(userBD);
            if (this._userSvc.SaveChanges())
                return Ok(model);

            return BadRequest();

        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(UserDataVM userInfo)
        {
            var user = this._userSvc.GetList().Where(x => x.Email == userInfo.Email && x.Password == userInfo.Password).FirstOrDefault();

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        [Route("GetUsers")]
        public ActionResult GetUsers()
        {
            var usersBD = this._userSvc.GetList();
            var UsersVM = this._mapper.Map<ICollection<UserData>,ICollection<UserDataVM>>(usersBD);
                return Ok(UsersVM);
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult Update(UserDataVM userDataVM)
        {
            var userBD = this._mapper.Map<UserDataVM, UserData>(userDataVM);

            this._userSvc.Update(userBD);

            if (this._userSvc.SaveChanges())
                return Ok(this._mapper.Map<UserData, UserDataVM>(userBD));

            return BadRequest();
        }

        [HttpDelete]
        [Route("Delete/{Id}")]
        public ActionResult Delete(int Id)
        {
            var userBD = this._userSvc.GetList().Where(x => x.Id == Id).FirstOrDefault();

            this._userSvc.Delete(userBD);

            if (this._userSvc.SaveChanges())
                return Ok();

            return BadRequest();
        }
    }
}