using System.ComponentModel.DataAnnotations;
namespace BlogForBlog.Models;
public class Tag
{
    [Key]
    public long TagId { get; set; }
    
    public long PostId { get; set; }

    // Navigation property
    public Post Post { get; set; } = null!;
    public TagDetail TagDetails { get; set; } = null!;
}
