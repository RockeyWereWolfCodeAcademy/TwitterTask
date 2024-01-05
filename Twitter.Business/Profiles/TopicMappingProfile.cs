using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.DTOs.TopicDTOs;
using Twitter.Core.Entities;

namespace Twitter.Business.Profiles
{
	public class TopicMappingProfile : Profile
	{
		public TopicMappingProfile()
		{
			CreateMap<TopicCreateDTO, Topic>();
			CreateMap<TopicUpdateDTO, Topic>();
			CreateMap<Topic, TopicListDTO>();
			CreateMap<Topic, TopicDetailDTO>();
		}
	}
}
