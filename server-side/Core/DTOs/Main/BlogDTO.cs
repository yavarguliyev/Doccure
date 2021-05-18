using Core.DTOs.Auth;

namespace Core.DTOs.Main
{
    public class BlogDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Video { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }

        public UserDTO Doctor { get; set; }
    }
}