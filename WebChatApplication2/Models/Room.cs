using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebChatApplication2.Models
{
    /// <summary>
    /// Model for rooms.
    /// </summary>
    public class Room
    {
        /// <summary>
        /// ID of room.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of room.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Collection of messages in room.
        /// </summary>
        public ICollection<Message> Messages { get; set; }
    }
}
