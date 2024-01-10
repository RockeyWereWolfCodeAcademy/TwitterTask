using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Core.Entities
{
	public class Blog : BaseEntity
    { 
        public string AuthorId { get; set; }
        public AppUser AppUser { get; set; }
        public string Content { get; set; }
        public bool Updated { get; set; }
        public DateTime UpdatedAt { get; set; }
		public int UpdatedCount { get; set; }
        public IEnumerable<BlogFile> Files { get; set; }
        public IEnumerable<BlogTopic> BlogTopics { get; set; }
    }
}
