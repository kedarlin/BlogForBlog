using System.ComponentModel.DataAnnotations;

namespace BlogForBlog.Models{
    public class TagDetail
    {
        [Key]
        public long Id { get; set; }
        
        public string Name { get; set; } = string.Empty;
        
        // Navigation property
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }

}