using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.DTOs.BlogFileDTOs;
using Twitter.Business.DTOs.TopicDTOs;
using Twitter.Core.Entities;

namespace Twitter.Business.Profiles
{
	public class BlogFileMappingProfile : Profile
	{
		public BlogFileMappingProfile()
		{
			CreateMap<BlogFileCreateDTO, BlogFile>();
			CreateMap<BlogFileUpdateDTO, BlogFile>();
			CreateMap<BlogFile, BlogFileListDTO>();
			CreateMap<BlogFile, BlogFileDetailDTO>();
		}
	}
}
