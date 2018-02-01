using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebChatApplication2.Models;
using WebChatApplication2.Data;
using Microsoft.EntityFrameworkCore;

namespace WebChatApplication2.Controllers
{
    /// <summary>
    /// Web API for Manipulating with rooms in DB through EntityFrameworkCore.
    /// </summary>
    [Produces("application/json")]
    [Route("api/Rooms")]
    public class RoomsController : Controller
    {
        /// <summary>
        /// DB context for web chat.
        /// </summary>
        private readonly ChatContext _context;

        /// <summary>
        /// Constructs controller with DB context.
        /// </summary>
        /// <param name="context">DB context</param>
        public RoomsController(ChatContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns all rooms from DB.
        /// </summary>
        /// <returns>All existing in DB rooms</returns>
        [HttpGet]
        public IEnumerable<Room> GetRooms()
        {
            return _context.Rooms;
        }

        /// <summary>
        /// Returns room with last 30 messages in it from DB asynchronously by ID of room.
        /// </summary>
        /// <param name="id">ID of room</param>
        /// <returns>Room with last 30 messages</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomWithLast30Messages([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var room = await _context.Rooms.Include(m=>m.Messages).AsNoTracking().SingleOrDefaultAsync(m => m.Id == id);

            if (room == null)
            {
                return NotFound();
            }
            room.Messages = room.Messages.OrderBy(m=>m.CreatedDate).TakeLast(30).ToList();

            return Ok(room);
        }

        /// <summary>
        /// Creates room in DB asynchronously by its name.
        /// </summary>
        /// <param name="room"><see cref="Room"/> model object</param>
        /// <returns>Success response or fail in case of any error with model</returns>
        [HttpPost]
        public async Task<IActionResult> PostRoom([FromBody] Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }
    }
}