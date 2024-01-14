using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.DTOs.BlogDTOs;
using Twitter.Business.Exceptions.Common;
using Twitter.Business.Repositories.Interfaces;
using Twitter.Business.Services.Interfaces;
using Twitter.Core.Entities;

namespace Twitter.Business.Services.Implements
{
	public class BlogService : IBlogService
	{
		readonly IBlogRepository _repo;
		readonly IMapper _mapper;
		readonly IHttpContextAccessor _contextAccessor;
		readonly UserManager<AppUser> _userManager;
		readonly string _userId;

		public BlogService(IBlogRepository repo, IMapper mapper, IHttpContextAccessor contextAccessor)
		{
			_repo = repo;
			_mapper = mapper;
			_contextAccessor = contextAccessor;
            if (_contextAccessor.HttpContext.User.Claims.Any())
            {
                _userId = _contextAccessor.HttpContext?.User?.Claims?.First(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new NullReferenceException();
            }
        }

		public async Task CreateAsync(BlogCreateDTO blog)
		{
			var data = _mapper.Map<Blog>(blog);
			data.AuthorId = _userId;
            await _repo.CreateAsync(data);
			await _repo.SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var data = await _checkId(id);
			_repo.Delete(data);
			await _repo.SaveAsync();
		}

		public IEnumerable<BlogListDTO> GetAll()
			=> _mapper.Map<IEnumerable<BlogListDTO>>(_repo.GetAll(includes: "AppUser")); //.Include(x=> x.AppUser)
        public async Task<BlogDetailDTO> GetByIdAsync(int id)
		{
			var data = await _checkId(id, true);
			return _mapper.Map<BlogDetailDTO>(data);
		}

		public async Task UpdateAsync(int id, BlogUpdateDTO dto)
		{
			var data = await _checkId(id);
			data = _mapper.Map(dto, data);
			await _repo.SaveAsync();
		}

        public async Task SoftDelete(int id)
        {
            var data = await _checkId(id);
            data.IsDeleted = true;
            await _repo.SaveAsync();
        }

        public async Task ReverseSoftDelete(int id)
        {
            var data = await _checkId(id);
            data.IsDeleted = false;
            await _repo.SaveAsync();
        }

        async Task<Blog> _checkId(int id, bool isTrack = false)
		{
			if (id <= 0) throw new ArgumentException();
			var data = await _repo.GetByIdAsync(id, isTrack, "AppUser");
			if (data == null) throw new NotFoundException<Blog>();
			return data;
		}
	}
}
