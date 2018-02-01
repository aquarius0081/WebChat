namespace WebChatApplication2.ViewModels
{
    /// <summary>
    /// DTO for messages.
    /// </summary>
    public class MessageDto
    {
        /// <summary>
        /// ID of room corresponding to message.
        /// </summary>
        public int RoomId { get; set; }

        /// <summary>
        /// Author of message.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Date with time string when message has been created.
        /// </summary>
        public string CreatedDate { get; set; }

        /// <summary>
        /// Text of message.
        /// </summary>
        public string Text { get; set; }
    }
}
