using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebChatApplication2.Data;
using WebChatApplication2.Models;

namespace WebChatApplication2.Controllers
{
    /// <summary>
    /// Web API for Manipulating with chat messages in DB through EntityFrameworkCore.
    /// </summary>
    [Produces("application/json")]
    [Route("api/Messages")]
    public class MessagesController : Controller
    {
        /// <summary>
        /// DB context for web chat.
        /// </summary>
        private readonly ChatContext _context;

        /// <summary>
        /// Constructs controller with DB context.
        /// </summary>
        /// <param name="context">DB context</param>
        public MessagesController(ChatContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates message asynchronously in DB using message text, author of message and ID of room.
        /// </summary>
        /// <param name="message"><see cref="Message"/> model object</param>
        /// <returns>Success response or fail response in case of any errors with model</returns>
        [HttpPost]
        public async Task<IActionResult> PostMessage([FromBody] Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            message.CreatedDate = DateTime.Now;
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessage", new { id = message.Id }, message);
        }
    }
}