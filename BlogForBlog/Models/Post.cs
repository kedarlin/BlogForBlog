using System.ComponentModel.DataAnnotations;

namespace BlogForBlog.Models{
    public class Post
    {
        [Key]
        public long Id { get; set; }
        
        [Required]
        public string Title { get; set; } = "";
        
        public string Content { get; set; } = "";
        
        [Required]
        public long UserId { get; set; }
        
        public DateTime Time { get; set; }

        // Navigation properties
        public User User { get; set; } = null!;
        public ICollection<Comment> Comments { get; set; } = null!;
        public ICollection<Tag> Tags { get; set; } = null!;
    }

}