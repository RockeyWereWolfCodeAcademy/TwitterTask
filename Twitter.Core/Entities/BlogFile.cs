using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Core.Entities
{
	public class BlogFile : BaseEntity
	{
		public string Name { get; set; }
		public string Path { get; set; }
        public string ContentType { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
