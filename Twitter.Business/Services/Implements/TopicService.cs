using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.DTOs.TopicDTOs;
using Twitter.Business.Repositories.Interfaces;
using Twitter.Business.Services.Interfaces;
using Twitter.Core.Entities;

namespace Twitter.Business.Services.Implements
{
    public class TopicService : ITopicService
    {
        readonly ITopicRepository _repo;

        public TopicService(ITopicRepository repo)
        {
            _repo = repo;
        }

        public async Task CreateAsync(TopicCreateDTO topic)
        {
            await _repo.CreateAsync(new Topic
            {
                Name = topic.Name,
            });
            await _repo.SaveAsync();
        }

        public IQueryable<TopicListDTO> GetAll()
            => _repo.GetAll().Select(t => new TopicListDTO
            {
                Id = t.Id,
                Name = t.Name,
            });

        public Task<TopicDetailDTO> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
