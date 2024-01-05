using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.DTOs.TopicDTOs;
using Twitter.Core.Entities;

namespace Twitter.Business.Services.Interfaces
{
    public interface ITopicService
    {
        public IEnumerable<TopicListDTO> GetAll();
        public Task<TopicDetailDTO> GetByIdAsync(int id);
        public Task CreateAsync (TopicCreateDTO topic);
		public Task DeleteAsync(int id);
		public Task UpdateAsync(int id, TopicUpdateDTO topic);
	}
}
