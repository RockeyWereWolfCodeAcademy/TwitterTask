using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public BlogService(IBlogRepository repo, IMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}

		public async Task CreateAsync(BlogCreateDTO blog)
		{
			Blog blogToCreate = new Blog
			{
				Content = blog.Content,
				Author = blog.Author,
				BlogTopics = blog.TopicIds.Select(id => new BlogTopic {
					TopicId = id,
				}).ToList(),
			};
			await _repo.CreateAsync(_mapper.Map<Blog>(blog));
			await _repo.SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var data = await _checkId(id);
			_repo.Delete(data);
			await _repo.SaveAsync();
		}

		public IEnumerable<BlogListDTO> GetAll()
			=> _mapper.Map<IEnumerable<BlogListDTO>>(_repo.GetAll());
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

		async Task<Blog> _checkId(int id, bool isTrack = false)
		{
			if (id <= 0) throw new ArgumentException();
			var data = await _repo.GetByIdAsync(id, isTrack);
			if (data == null) throw new NotFoundException<Blog>();
			return data;
		}
	}
}
