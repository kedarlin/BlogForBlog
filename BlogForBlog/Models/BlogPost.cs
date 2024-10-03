namespace BlogForBlog.Models
{
    public class BlogPost{
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty ;
        public string Author { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set;}
        public List<string> Tags { get; set; } = new List<string> ();
    }
}