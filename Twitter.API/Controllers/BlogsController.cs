﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twitter.Business.DTOs.BlogDTOs;
using Twitter.Business.Services.Interfaces;

namespace Twitter.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogsController : ControllerBase
	{
		readonly IBlogService _service;
		public BlogsController(IBlogService service)
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
		[Route("Create")]
		public async Task<IActionResult> Create(BlogCreateDTO Blog)
		{
			await _service.CreateAsync(Blog);
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
		public async Task<IActionResult> Update(int id, BlogUpdateDTO dto)
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
