using Core.DTOs.Auth;
using System;

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
        public int CommentCount { get; set; }
        public DateTime AddedDate { get; set; }

        public UserDTO Doctor { get; set; }
    }
}