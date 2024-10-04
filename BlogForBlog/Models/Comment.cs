using System.ComponentModel.DataAnnotations;

namespace BlogForBlog.Models
{
    public class Comment
{
    [Key]
    public long Id { get; set; }
    
    public string Content { get; set; } = "";

    [Required]
    public long UserId { get; set; }

    [Required]
    public long PostId { get; set; }

    public DateTime Time { get; set; }

    // Navigation properties
    public User User { get; set; } = null!;
    public Post Post { get; set; } = null!;
}

}