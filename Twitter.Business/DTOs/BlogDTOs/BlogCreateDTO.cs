using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.DTOs.TopicDTOs;
using Twitter.Core.Entities;

namespace Twitter.Business.DTOs.BlogDTOs
{
	public class BlogCreateDTO
	{
		public string Author { get; set; }
		public string Content { get; set; }
		public IEnumerable<int> TopicIds { get; set; }
	}

	public class BlogCreateDTOValidator : AbstractValidator<BlogCreateDTO>
	{
		public BlogCreateDTOValidator()
		{
			RuleFor(x => x.Content)
				.NotEmpty()
				.MinimumLength(2)
				.MaximumLength(2048);
		}
	}
}
