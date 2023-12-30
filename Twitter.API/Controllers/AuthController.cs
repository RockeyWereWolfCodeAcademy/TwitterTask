using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twitter.Business.ExternalServices.Interfaces;

namespace Twitter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IEmailService _emailService;

        public AuthController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        //reg

        //log
    }
}
