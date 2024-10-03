using BlogForBlog.Models;

public interface IBlogPostService
{
    Task<IEnumerable<BlogPost>> GetAllPostsAsync();
    Task<BlogPost> GetPostByIdAsync(int id);
    Task AddPostAsync(BlogPost post);
    Task UpdatePostAsync(int id, BlogPost post);
    Task DeletePostAsync(int id);
}