using Microsoft.EntityFrameworkCore;
using WebChatApplication2.Models;

namespace WebChatApplication2.Data
{
    /// <summary>
    /// DB context of EntityFrameworkCore for chat
    /// </summary>
    public class ChatContext : DbContext
    {
        /// <summary>
        /// Constructs context with specified options.
        /// </summary>
        /// <param name="options">DB context options</param>
        public ChatContext(DbContextOptions<ChatContext> options) : base(options)
        {
        }

        /// <summary>
        /// DB set for rooms.
        /// </summary>
        public DbSet<Room> Rooms { get; set; }

        /// <summary>
        /// DB set for messages.
        /// </summary>
        public DbSet<Message> Messages { get; set; }

        /// <summary>
        /// Maps Model to DB.
        /// </summary>
        /// <param name="modelBuilder">Model builder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Message>().ToTable("Message");
        }
    }
}
