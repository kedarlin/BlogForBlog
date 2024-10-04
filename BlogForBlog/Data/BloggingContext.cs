using Microsoft.EntityFrameworkCore;
using BlogForBlog.Models;

namespace BlogForBlog.Data{
    public class BloggingContext : DbContext
{
    public BloggingContext(DbContextOptions<BloggingContext> options) : base(options) {}

    public DbSet<User> Users { get; set; }
    public DbSet<LoginCredits> LoginCredits { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TagDetail> TagDetails { get; set; }
    public DbSet<BlogPost> BlogPosts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User - LoginCredits one-to-one relationship
        modelBuilder.Entity<User>()
            .HasOne(u => u.LoginCredits)
            .WithOne(lc => lc.User)
            .HasForeignKey<LoginCredits>(lc => lc.UserId);

        // Post - User one-to-many relationship
        modelBuilder.Entity<Post>()
            .HasOne(p => p.User)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.UserId);

        // Comment - User one-to-many relationship
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId);

        // Comment - Post one-to-many relationship
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Post)
            .WithMany(p => p.Comments)
            .HasForeignKey(c => c.PostId);

        // Tag - Post one-to-many relationship
        modelBuilder.Entity<Tag>()
            .HasOne(t => t.Post)
            .WithMany(p => p.Tags)
            .HasForeignKey(t => t.PostId);

        // Tag - TagDetails one-to-many relationship
        modelBuilder.Entity<TagDetail>()
            .HasMany(td => td.Tags)
            .WithOne(t => t.TagDetails)
            .HasForeignKey(t => t.TagId);
    }
}

}