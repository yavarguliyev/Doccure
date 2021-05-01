using Core.DTOs.Auth;
using System.Collections.Generic;

namespace Core.DTOs.Main
{
    public class ChatDTO
    {
        public int Id { get; set; }
        public UserDTO Doctor { get; set; }
        public UserDTO Patient { get; set; }

        public IEnumerable<ChatMessageDTO> ChatMessageDTOs { get; set; }
    }
}