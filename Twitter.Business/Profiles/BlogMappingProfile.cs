using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Twitter.Business.DTOs.BlogDTOs;
using Twitter.Core.Entities;

namespace Twitter.Business.Profiles
{
	public class BlogMappingProfile : Profile
	{
		public BlogMappingProfile()
		{
			CreateMap<BlogCreateDTO, Blog>();
			CreateMap<BlogUpdateDTO, Blog>();
			CreateMap<Blog, BlogListDTO>().ForMember(dto=> dto.Topics, opt=> opt.MapFrom(blog=> blog.BlogTopics.Select(t=> t.Topic).ToList()));
			CreateMap<Blog, BlogDetailDTO>();
		}
	}
}
