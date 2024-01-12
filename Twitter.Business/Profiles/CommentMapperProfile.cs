using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.DTOs.BlogDTOs;
using Twitter.Business.DTOs.CommentDTOs;
using Twitter.Core.Entities;

namespace Twitter.Business.Profiles
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<Comment, CommentListDTO>().ForMember(dto => dto.Author, opt => opt.MapFrom(blog => blog.AppUser));
        }
    }
}
