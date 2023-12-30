using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entities;
using Twitter.Core.Entities.Common;
using Twitter.DAL.Configurations;

namespace Twitter.DAL.Contexts
{
    public class TwitterContext : IdentityDbContext<AppUser>
    {
        public TwitterContext(DbContextOptions options) : base(options) { }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<AppUser> Users {  get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            foreach (var entry in entries)
            {
                if(entry.State == EntityState.Added)
                    entry.Entity.CreatedAt = DateTime.Now;
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
