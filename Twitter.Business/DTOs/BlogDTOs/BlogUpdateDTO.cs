using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Business.DTOs.BlogDTOs
{
	public class BlogUpdateDTO
	{
		public string Author { get; set; }
		public string Content { get; set; }
	}

	public class BlogUpdateDTOValidator : AbstractValidator<BlogUpdateDTO>
	{
		public BlogUpdateDTOValidator()
		{
			RuleFor(x => x.Content)
				.NotEmpty()
				.MinimumLength(2)
				.MaximumLength(2048);
		}
	}
}
