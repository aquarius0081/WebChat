using System;
using System.ComponentModel.DataAnnotations;

namespace WebChatApplication2.Models
{
    /// <summary>
    /// Model for messages.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// ID of message.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID of room corresponding to message.
        /// </summary>
        [Required]
        public int RoomId { get; set; }
        
        /// <summary>
        /// Author of message.
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Author { get; set; }

        /// <summary>
        /// Date with time when message has been created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Text of message.
        /// </summary>
        [Required]
        public string Text { get; set; }
    }
}
