using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entities;

namespace Twitter.Business.DTOs.BlogFileDTOs
{
	public class BlogFileCreateDTO
	{
		public string Name { get; set; }
		public string Path { get; set; }
		public string ContentType { get; set; }
		public int BlogId { get; set; }
	}
}
