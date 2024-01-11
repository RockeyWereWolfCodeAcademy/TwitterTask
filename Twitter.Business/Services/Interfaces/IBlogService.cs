using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.DTOs.BlogDTOs;

namespace Twitter.Business.Services.Interfaces
{
	public interface IBlogService
	{
		public IEnumerable<BlogListDTO> GetAll();
		public Task<BlogDetailDTO> GetByIdAsync(int id);
		public Task CreateAsync(BlogCreateDTO topic);
		public Task DeleteAsync(int id);
		public Task UpdateAsync(int id, BlogUpdateDTO topic);
		public Task SoftDelete(int id);
        public Task ReverseSoftDelete(int id);
    }
}
