using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.DTOs.BlogFileDTOs;

namespace Twitter.Business.Services.Interfaces
{
	public interface IBlogFileService
	{
		public IEnumerable<BlogFileListDTO> GetAll();
		public Task<BlogFileDetailDTO> GetByIdAsync(int id);
		public Task CreateAsync(BlogFileCreateDTO topic);
		public Task DeleteAsync(int id);
		public Task UpdateAsync(int id, BlogFileUpdateDTO topic);
	}
}
