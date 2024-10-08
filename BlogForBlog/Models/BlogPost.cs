using System;
using System.ComponentModel.DataAnnotations;

namespace BlogForBlog.Models
{
    public class BlogPost
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Title { get; set; } = "";

        [Required]
        public string Content { get; set; } = "";

        public long UserId { get; set; }
        public DateTime Time { get; set; }

        // Navigation properties
        public User User { get; set; } = null!;
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
