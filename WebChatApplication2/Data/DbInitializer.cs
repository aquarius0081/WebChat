using System;
using System.Linq;
using WebChatApplication2.Models;

namespace WebChatApplication2.Data
{
    /// <summary>
    /// Initializion of DB with test data.
    /// </summary>
    public class DbInitializer
    {
        /// <summary>
        /// Initializes DB with test data using specified DB context for chat in case if DB is empty.
        /// Nothing happens in case of DB is not empty.
        /// </summary>
        /// <param name="context">DB context for chat</param>
        public static void Initialize(ChatContext context)
        {
            context.Database.EnsureCreated();

            if (context.Rooms.Any())
            {
                return;   // DB has been seeded
            }

            var rooms = new Room[]
            {
            new Room{ Name = "Room1"}
            };
            foreach (Room r in rooms)
            {
                context.Rooms.Add(r);
            }
            context.SaveChanges();

            var messages = new Message[]
            {
            new Message{ Author="Ivan", RoomId = 1, CreatedDate=DateTime.Parse("2002-09-01"), Text="Some text"}
            };
            foreach (Message m in messages)
            {
                context.Messages.Add(m);
            }
            context.SaveChanges();
        }
    }
}
