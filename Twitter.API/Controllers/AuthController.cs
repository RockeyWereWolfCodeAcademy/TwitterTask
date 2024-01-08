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
using System.IdentityModel.Tokens.Jwt;
using Twitter.Business.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
		readonly IConfiguration _config;


        public AuthController(IEmailService emailService, IMapper mapper, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IConfiguration config)
        {
            _emailService = emailService;
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
        }
        [HttpGet]
		[Route("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return new BadRequestObjectResult(new { Message = "Unexpected error" });
            var result = await _userManager.ConfirmEmailAsync(user, token);
            return new BadRequestObjectResult(result.Succeeded ? nameof(ConfirmEmail) : new { Message = "Unexpected error"});
        }

        //reg
        [HttpPost]
		[Route("Register")]
		public async Task<IActionResult> Register(RegisterDTO dto)
        {
			var user = _mapper.Map<AppUser>(dto);
            var result = await _userManager.CreateAsync(user, dto.Password);
			if (!result.Succeeded) 
			{
				var dictionary = new ModelStateDictionary();
				foreach (IdentityError error in result.Errors)
				{
					dictionary.AddModelError(error.Code, error.Description);
				}

				return new BadRequestObjectResult(new { Message = "User Registration Failed", Errors = dictionary });
			}
            
            await _emailService.SendEmail(dto.Email, "Welcome", $"<h1>Welcome to our system {dto.UserName}!</h1>" +
				$"<p>Now you need to confirm your account {await GenerateConfirmationLink(user)} </p>");
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
			if (!await _signInManager.CanSignInAsync(user))
			{
                return new BadRequestObjectResult(new { Message = "Login failed. Confirm your account!" });
            }

            var tokenString = GenerateJSONWebToken(user);

			return Ok(new { Message = "User is logged in token: "+tokenString });
		}

        private async Task<string> GenerateConfirmationLink(AppUser user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Auth", new { token, email = user.Email }, Request.Scheme);
            return confirmationLink;
        }

        private string GenerateJSONWebToken(AppUser user)
        {
            
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
