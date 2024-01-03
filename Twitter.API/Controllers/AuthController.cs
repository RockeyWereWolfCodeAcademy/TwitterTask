using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using Twitter.Business.DTOs.AuthDTOs;
using Twitter.Business.ExternalServices.Interfaces;
using Twitter.Core.Entities;

namespace Twitter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IEmailService _emailService;
        readonly IMapper _mapper;
		readonly SignInManager<AppUser> _signInManager;
	    readonly UserManager<AppUser> _userManager;

		public AuthController(IEmailService emailService, IMapper mapper, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _emailService = emailService;
            _mapper = mapper;
			_signInManager = signInManager;
			_userManager = userManager;
        }

        //reg
        [HttpPost]
		[Route("Register")]
		public async Task<IActionResult> Register(RegisterDTO dto)
        {
			var result = await _userManager.CreateAsync(_mapper.Map<AppUser>(dto), dto.Password);
			if (!result.Succeeded) 
			{
				var dictionary = new ModelStateDictionary();
				foreach (IdentityError error in result.Errors)
				{
					dictionary.AddModelError(error.Code, error.Description);
				}

				return new BadRequestObjectResult(new { Message = "User Registration Failed", Errors = dictionary });
			}
			await _emailService.SendEmail(dto.Email, "Welcome", $"<em>Welcome to our system {dto.UserName}!</em>");
			return Ok(new { Message = "User Reigstration Successful" });
		}

		//log
		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login(LoginDTO dto)
		{
			var user = await _userManager.FindByEmailAsync(dto.UsernameOrEmail) ?? await _userManager.FindByNameAsync(dto.UsernameOrEmail);   /*await userManager.FindByNameAsync(credentials.Username);*/
			if (user == null)
			{
				return new BadRequestObjectResult(new { Message = "Login failed. Check your credentials!" });
			}

			var result = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
			if (result == PasswordVerificationResult.Failed)
			{
				return new BadRequestObjectResult(new { Message = "Login failed. Check your credentials!" });
			}

			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Email, user.Email),
				new Claim(ClaimTypes.Name, user.UserName)
			};

			var claimsIdentity = new ClaimsIdentity(
				claims, CookieAuthenticationDefaults.AuthenticationScheme);

			await HttpContext.SignInAsync(
				CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(claimsIdentity));

			return Ok(new { Message = "You are logged in" });
		}
	}
}
