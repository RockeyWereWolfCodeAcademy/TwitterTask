using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.DTOs.BlogDTOs;
using Twitter.Business.DTOs.CommentDTOs;
using Twitter.Business.DTOs.TopicDTOs;
using Twitter.Business.Repositories.Interfaces;
using Twitter.Business.Services.Interfaces;

namespace Twitter.Business.Services.Implements
{
    public class CommentService : ICommentService
    {
        readonly IMapper _mapper;
        readonly ICommentRepository _repo;

        public CommentService(IMapper mapper, ICommentRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public IEnumerable<CommentListDTO> GetAll()
            => _mapper.Map<IEnumerable<CommentListDTO>>(_repo.GetAll());

    }
}
