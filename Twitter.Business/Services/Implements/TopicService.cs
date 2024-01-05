using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.DTOs.TopicDTOs;
using Twitter.Business.Exceptions.Common;
using Twitter.Business.Exceptions.Topic;
using Twitter.Business.Repositories.Interfaces;
using Twitter.Business.Services.Interfaces;
using Twitter.Core.Entities;

namespace Twitter.Business.Services.Implements
{
    public class TopicService : ITopicService
    {
        readonly ITopicRepository _repo;
		readonly IMapper _mapper;

		public TopicService(ITopicRepository repo, IMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}

		public async Task CreateAsync(TopicCreateDTO topic)
        {
			if (await _repo.IsExistAsync(r => r.Name.ToLower() == topic.Name.ToLower()))
				throw new TopicExistException();
			await _repo.CreateAsync(_mapper.Map<Topic>(topic));
			await _repo.SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var data = await _checkId(id);
			_repo.Delete(data);
			await _repo.SaveAsync();
		}

		public IEnumerable<TopicListDTO> GetAll()
			=> _mapper.Map<IEnumerable<TopicListDTO>>(_repo.GetAll());
		public async Task<TopicDetailDTO> GetByIdAsync(int id)
		{
			var data = await _checkId(id, true);
			return _mapper.Map<TopicDetailDTO>(data);
		}

		public async Task UpdateAsync(int id, TopicUpdateDTO dto)
		{
			var data = await _checkId(id);
			if (dto.Name.ToLower() != data.Name.ToLower())
			{
				if (await _repo.IsExistAsync(r => r.Name.ToLower() == dto.Name.ToLower()))
					throw new TopicExistException();
				data = _mapper.Map(dto, data);
				await _repo.SaveAsync();
			}
		}

		async Task<Topic> _checkId(int id, bool isTrack = false)
		{
			if (id <= 0) throw new ArgumentException();
			var data = await _repo.GetByIdAsync(id, isTrack);
			if (data == null) throw new NotFoundException<Topic>();
			return data;
		}
	}
}
