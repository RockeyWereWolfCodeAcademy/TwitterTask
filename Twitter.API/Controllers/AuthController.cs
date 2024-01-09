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
		readonly IConfiguration _config;
        readonly IUserService _userService;
        readonly IAuthService _authService;


        public AuthController(IEmailService emailService, IMapper mapper, IConfiguration config, IUserService userService, IAuthService authService)
        {
            _emailService = emailService;
            _mapper = mapper;
            _config = config;
            _userService = userService;
            _authService = authService;
        }
        [HttpGet]
		[Route("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var result = await _authService.ConfirmEmail(token, email);
            var response = result == true ? nameof(ConfirmEmail) : "Unexpected error";
            return new BadRequestObjectResult(response);
        }

        //reg
        [HttpPost]
		[Route("Register")]
		public async Task<IActionResult> Register(RegisterDTO dto)
        {
            await _userService.CreateAsync(dto);
            
            _emailService.SendEmail(dto.Email, "Welcome", $"<h1>Welcome to our system {dto.UserName}!</h1>" +
				$"<p>Now you need to confirm your account {await GenerateConfirmationLink(dto)} </p>");
			return Ok(new { Message = "User Reigstration Successful, please check your email for confirmation link!" });
		}

		//log
		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login(LoginDTO dto)
		{
			return Ok(await _authService.Login(dto));
		}

        private async Task<string> GenerateConfirmationLink(RegisterDTO dto)
        {
            var user = _mapper.Map<AppUser>(dto);
            var token = await _authService.GetConfirmationToken(user);
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Auth", new { token, email = user.Email }, Request.Scheme);
            return confirmationLink;
        }
    }
}
