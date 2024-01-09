using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Twitter.Business.DTOs.BlogFileDTOs;
using Twitter.Business.Services.Interfaces;

namespace Twitter.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

    [Authorize]
    public class BlogFilesController : ControllerBase
	{
		readonly IBlogFileService _service;
		public BlogFilesController(IBlogFileService service)
		{
			_service = service;
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			return Ok(_service.GetAll());
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			try
			{
				return Ok(await _service.GetByIdAsync(id));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpPost]
		public async Task<IActionResult> Create(BlogFileCreateDTO BlogFile)
		{
			await _service.CreateAsync(BlogFile);
			return StatusCode(StatusCodes.Status201Created);
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				await _service.DeleteAsync(id);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, BlogFileUpdateDTO dto)
		{
			try
			{
				await _service.UpdateAsync(id, dto);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
