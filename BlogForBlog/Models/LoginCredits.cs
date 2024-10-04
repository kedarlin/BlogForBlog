using System.ComponentModel.DataAnnotations;
namespace BlogForBlog.Models;
public class LoginCredits
{
    [Key]
    public long UserId { get; set; }
    
    [Required]
    public string Username { get; set; } = "";
    
    [Required]
    public string Password { get; set; } = "";
    
    public string Role { get; set; } = "RegularUser";

    // Navigation property
    public User User { get; set; } = null!;
}
