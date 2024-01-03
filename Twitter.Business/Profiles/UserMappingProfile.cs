using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.DTOs.AuthDTOs;
using Twitter.Core.Entities;

namespace Twitter.Business.Profiles
{
	public class UserMappingProfile : Profile
	{
		public UserMappingProfile()
		{
			CreateMap<RegisterDTO, AppUser>();
		}
	}
}
