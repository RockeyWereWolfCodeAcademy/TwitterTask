using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entities;

namespace Twitter.Business.DTOs.BlogDTOs
{
	public class BlogListDTO
	{
		public string Author { get; set; }
		public string Content { get; set; }
        public IEnumerable<string> Topics { get; set; }
        public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}
