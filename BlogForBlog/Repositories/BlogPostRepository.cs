using BlogForBlog.Models;
using BlogForBlog.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogForBlog.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BloggingContext _context;

        public BlogPostRepository(BloggingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BlogPost>> GetAllPostsAsync()
        {
            return await _context.BlogPosts.ToListAsync();
        }

        public async Task<BlogPost> GetPostByIdAsync(int id)
        {
            return await _context.BlogPosts.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddPostAsync(BlogPost post)
        {
            _context.BlogPosts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(int id, BlogPost post)
        {
            var existingPost = await _context.BlogPosts.FindAsync(id);
            if (existingPost != null)
            {
                existingPost.Title = post.Title;
                existingPost.Content = post.Content;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await _context.BlogPosts.FindAsync(id);
            if (post != null)
            {
                _context.BlogPosts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }
    }
}

// namespace BlogForBlog.Repositories{
//     public class BlogPostRepository{
//         private readonly BloggingContext _context;
//         public BlogPostRepository(BloggingContext context){
//             _context = context;
//         }

//         public async Task<IEnumerable<BlogPost>> GetAllAsync(){
//             return await _context.BlogPosts.ToListAsync();
//         }

//         public async Task<BlogPost> GetByIdAsync(int id){
//             return await _context.BlogPosts.FindAsync(id);
//         }

//         public async Task AddAsync(BlogPost blogPost){
//             blogPost.CreatedAt = DateTime.Now;
//             await _context.BlogPosts.AddAsync(blogPost);
//             await _context.SaveChangesAsync();
//         }

//         public async Task UpdateAsync(BlogPost blogPost){
//             _context.BlogPosts.Update(blogPost);
//             await _context.SaveChangesAsync();
//         }

//         public async Task DeleteAsync(BlogPost blogPost){
//             _context.BlogPosts.Remove(blogPost);
//             await _context.SaveChangesAsync();
//         }

//         public bool Exists(int id){
//             return _context.BlogPosts.Any(e => e.Id == id);
//         }
//     }
// }