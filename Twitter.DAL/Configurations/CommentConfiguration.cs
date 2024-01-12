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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.Content)
                .IsRequired()
                .HasMaxLength(128);
            builder.HasOne(x => x.AppUser)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Blog)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.BlogId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.ParentComment)
                .WithMany(x => x.ChildComments)
                .HasForeignKey(x => x.ParentCommentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
