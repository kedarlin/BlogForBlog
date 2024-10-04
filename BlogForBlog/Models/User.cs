using System.ComponentModel.DataAnnotations;

namespace BlogForBlog.Models{
    public class User
    {
        [Key]
        public long Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;

        // Navigation properties
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public LoginCredits LoginCredits { get; set; } = null!;
    }
}
