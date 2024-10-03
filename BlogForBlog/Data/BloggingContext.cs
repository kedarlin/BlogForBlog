using Microsoft.EntityFrameworkCore;
using BlogForBlog.Models;

namespace BlogForBlog.Data{
    public class BloggingContext : DbContext{
        public BloggingContext(DbContextOptions<BloggingContext> options) : base(options) { }
        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}