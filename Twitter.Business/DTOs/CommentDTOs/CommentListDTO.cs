using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Business.DTOs.CommentDTOs
{
    public class CommentListDTO
    {
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int ParentCommentId { get; set; }
    }
}
