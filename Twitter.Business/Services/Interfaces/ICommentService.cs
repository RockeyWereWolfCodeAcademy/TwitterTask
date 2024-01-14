using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.DTOs.BlogDTOs;
using Twitter.Business.DTOs.CommentDTOs;

namespace Twitter.Business.Services.Interfaces
{
    public interface ICommentService
    {
        public IEnumerable<CommentListDTO> GetAll();
       // public Task<BlogDetailDTO> GetByIdAsync(int id);
       // public Task CreateAsync(CommentCreateDTO topic);
        //public Task DeleteAsync(int id);
       // public Task UpdateAsync(int id, BlogUpdateDTO topic);
      //  public Task SoftDelete(int id);
        //public Task ReverseSoftDelete(int id);
    }
}
