using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
// using AutoMapper.Configuration;
using crudApi.A_Application.ViewModels;
using crudApi.B_Service;
using crudApi.C_Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace crudApi.A_Application.Controllers
{
    [Route("User")]
    [ApiController]

    // [AllowAn]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly IConfiguration _configuration;
        private readonly IUserService _userSvc;

        private readonly IMapper _mapper;

        public UserController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, IConfiguration configuration, IUserService userService, IMapper mapper
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _userSvc = userService;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Post([FromBody] UserDataVM model)
        {
            var user = new IdentityUser { Email = model.Email, UserName = model.Email };

            var result = await _userManager.CreateAsync(user, model.PassWord);
            if (result.Succeeded)
            {
                var userBD = this._mapper.Map<UserDataVM, UserData>(model);
                this._userSvc.Add(userBD);
                if (this._userSvc.SaveChanges())
                    return Ok(model);

                return BadRequest();
            }
            else
            {
                var errors = "";
                foreach (var err in result.Errors)
                {
                    errors += err.Description + " ,";
                }
                return BadRequest(errors);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<UserToken>> Login(UserDataVM userInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.PassWord,
                 isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return BuildToken(userInfo);
            }
            else
            {
                return BadRequest("Invalid user or password, try again.");
            }
        }

        [HttpGet]
        [Route("GetByEmail/{email}")]
        public ActionResult<UserDataVM> GetByEmail(string email)
        {
            var user = this._userSvc.GetList().Where(x => x.Email == email).FirstOrDefault();

            return Ok(user);
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult<UserDataVM> Update(UserDataVM userDataVM)
        {
            var userBD = this._mapper.Map<UserDataVM, UserData>(userDataVM);

            this._userSvc.Update(userBD);

            if (this._userSvc.SaveChanges())
                return Ok(this._mapper.Map<UserData, UserDataVM>(userBD));

            return BadRequest();

        }

        [HttpDelete]
        [Route("Delete/{Id}")]
        public ActionResult<UserDataVM> Delete(int Id)
        {
            var userBD = this._userSvc.GetList().Where(x => x.Id == Id).FirstOrDefault();

            this._userSvc.Delete(userBD);

            if (this._userSvc.SaveChanges())
                return Ok();

            return BadRequest();

        }

        private UserToken BuildToken(UserDataVM userInfo)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // tempo de expiração do token: 1 hora
            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               expires: expiration,
               signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
                Name = userInfo.Email
            };
        }
    }
}