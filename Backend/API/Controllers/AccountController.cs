using API.Dtos.Account;
using API.Entities.Identity;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager
            , IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Verifies if the email is already registered
        /// </summary>
        /// <param name="email">An email to check out</param>
        /// <returns>A boolean</returns>
        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {

            return await _userManager.FindByEmailAsync(email) != null;
        }

        /// <summary>
        /// Sign up
        /// </summary>
        /// <param name="registerDto">The information of a user to sign up</param>
        /// <returns></returns>
        [HttpPost("register")]        
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (CheckEmailExistsAsync(registerDto.Email).Result.Value)
            {
                return BadRequest("Email address is in use");
            }

            var user = new AppUser
            {
                UserName = registerDto.Name,
                Email = registerDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) return BadRequest();

            return new UserDto
            {
                Name = user.UserName,
                Email = user.Email
            };
        }

        /// <summary>
        /// Log-in 
        /// </summary>
        /// <param name="loginDto">The information of a user to log in</param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
            {
                return Unauthorized();
            }

            //var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            //if (!result.Succeeded) return Unauthorized();

            return new UserDto
            {
                Email = user.Email,
                //Token = _tokenService.CreateToken(user),
                Name = user.UserName
            };
        }

    }
}
