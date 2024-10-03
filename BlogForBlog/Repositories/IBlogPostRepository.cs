using BlogForBlog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IBlogPostRepository
{
    Task<IEnumerable<BlogPost>> GetAllPostsAsync();
    Task<BlogPost> GetPostByIdAsync(int id);
    Task AddPostAsync(BlogPost post);
    Task UpdatePostAsync(int id, BlogPost post);
    Task DeletePostAsync(int id);
}
