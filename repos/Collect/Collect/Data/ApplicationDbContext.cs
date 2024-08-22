using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Collect.Data;

namespace Collect.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Collection> Collections { get; set; } = default!;
        public DbSet<Comment> Comments;
        public DbSet<Item> Items { get; set; } = default!;
        public DbSet<Tag> Tags;
        public DbSet<Topic> Topics;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Collections = Set<Collection>();
            Comments = Set<Comment>();
            Items = Set<Item>();
            Tags = Set<Tag>();
            Topics = Set<Topic>();
        }
    }
}
