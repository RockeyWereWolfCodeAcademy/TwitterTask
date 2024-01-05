using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.DTOs.BlogFileDTOs;
using Twitter.Business.Exceptions.Common;
using Twitter.Business.Repositories.Interfaces;
using Twitter.Business.Services.Interfaces;
using Twitter.Core.Entities;

namespace Twitter.Business.Services.Implements
{
	public class BlogFileService : IBlogFileService
	{
		readonly IBlogFileRepository _repo;
		readonly IMapper _mapper;

		public BlogFileService(IBlogFileRepository repo, IMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}

		public async Task CreateAsync(BlogFileCreateDTO blogFile)
		{
			await _repo.CreateAsync(_mapper.Map<BlogFile>(blogFile));
			await _repo.SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var data = await _checkId(id);
			_repo.Delete(data);
			await _repo.SaveAsync();
		}

		public IEnumerable<BlogFileListDTO> GetAll()
			=> _mapper.Map<IEnumerable<BlogFileListDTO>>(_repo.GetAll());
		public async Task<BlogFileDetailDTO> GetByIdAsync(int id)
		{
			var data = await _checkId(id, true);
			return _mapper.Map<BlogFileDetailDTO>(data);
		}

		public async Task UpdateAsync(int id, BlogFileUpdateDTO dto)
		{
			var data = await _checkId(id);
			data = _mapper.Map(dto, data);
			await _repo.SaveAsync();
		}

		async Task<BlogFile> _checkId(int id, bool isTrack = false)
		{
			if (id <= 0) throw new ArgumentException();
			var data = await _repo.GetByIdAsync(id, isTrack);
			if (data == null) throw new NotFoundException<BlogFile>();
			return data;
		}
	}
}
