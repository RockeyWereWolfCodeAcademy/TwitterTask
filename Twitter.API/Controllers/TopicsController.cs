using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twitter.Business.DTOs.TopicDTOs;
using Twitter.Business.Repositories.Interfaces;
using Twitter.Business.Services.Interfaces;

namespace Twitter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        readonly ITopicService _service;
        public TopicsController(ITopicService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> Create(TopicCreateDTO topic)
        {
            await _service.CreateAsync(topic);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
