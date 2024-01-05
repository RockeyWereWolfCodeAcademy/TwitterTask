using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entities;

namespace Twitter.DAL.Configurations
{
	public class BlogConfiguraion : IEntityTypeConfiguration<Blog>
	{
		public void Configure(EntityTypeBuilder<Blog> builder)
		{
			builder.Property(t => t.Content)
				.IsRequired()
				.HasMaxLength(2048);
			builder.Property(t => t.Updated)
				.HasDefaultValue(false);
		}
	}
}
