using BlogForBlog.Models;
using BlogForBlog.Repositories;

namespace BlogForBlog.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public BlogPostService(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task<IEnumerable<BlogPost>> GetAllPostsAsync()
        {
            return await _blogPostRepository.GetAllPostsAsync();
        }

        public async Task<BlogPost> GetPostByIdAsync(int id)
        {
            return await _blogPostRepository.GetPostByIdAsync(id);
        }

        public async Task AddPostAsync(BlogPost post)
        {
            await _blogPostRepository.AddPostAsync(post);
        }

        public async Task UpdatePostAsync(int id, BlogPost post)
        {
            await _blogPostRepository.UpdatePostAsync(id, post);
        }

        public async Task DeletePostAsync(int id)
        {
            await _blogPostRepository.DeletePostAsync(id);
        }
    }
}











// namespace BlogForBlog.Services{
//     public class BlogPostService{
//         private readonly BlogPostRepository _repository;

//         public BlogPostService(BlogPostRepository repository){
//             _repository = repository;
//         }

//         public async Task<IEnumerable<BlogPost>> GetAllBlogPostAsync(){
//             return await _repository.GetAllAsync();
//         }

//         public async Task<BlogPost> GetBlogPostByIdAsync(int id){
//             return await _repository.GetByIdAsync(id);
//         }

//         public async Task AddBLogPostAsync(BlogPost blogPost){
//             await _repository.AddAsync(blogPost);
//         }

//         public async Task UpdateBlogPostAsync(BlogPost blogPost){
//             await _repository.UpdateAsync(blogPost);
//         }

//         public async Task DeleteBlogPostAsync(int id){
//             var blogPost = await _repository.GetByIdAsync(id);
//             if(blogPost != null){
//                 await _repository.DeleteAsync(blogPost);
//             }
//         }

//         public bool BlogPostExists(int id){
//             return _repository.Exists(id);
//         }
//     }
// }