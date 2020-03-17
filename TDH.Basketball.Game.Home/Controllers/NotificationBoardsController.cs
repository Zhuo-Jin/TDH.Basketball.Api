using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TDH.Basketball.Game.EF.Core;
using TDH.Basketball.Game.EF.Core.EntityClasses;

namespace TDH.Basketball.Game.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationBoardsController : ControllerBase
    {
        private readonly TDHDBContext _context;

        public NotificationBoardsController(TDHDBContext context)
        {
            _context = context;
        }

        // GET: api/NotificationBoards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificationBoard>>> GetNotificationBoards()
        {
            return await _context.NotificationBoards.ToListAsync();
        }

        // GET: api/NotificationBoards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NotificationBoard>> GetNotificationBoard(int id)
        {
            var notificationBoard = await _context.NotificationBoards.FindAsync(id);

            if (notificationBoard == null)
            {
                return NotFound();
            }

            return notificationBoard;
        }

        // PUT: api/NotificationBoards/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotificationBoard(int id, NotificationBoard notificationBoard)
        {
            if (id != notificationBoard.Id)
            {
                return BadRequest();
            }

            _context.Entry(notificationBoard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificationBoardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/NotificationBoards
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<NotificationBoard>> PostNotificationBoard(NotificationBoard notificationBoard)
        {
            _context.NotificationBoards.Add(notificationBoard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotificationBoard", new { id = notificationBoard.Id }, notificationBoard);
        }

        // DELETE: api/NotificationBoards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NotificationBoard>> DeleteNotificationBoard(int id)
        {
            var notificationBoard = await _context.NotificationBoards.FindAsync(id);
            if (notificationBoard == null)
            {
                return NotFound();
            }

            _context.NotificationBoards.Remove(notificationBoard);
            await _context.SaveChangesAsync();

            return notificationBoard;
        }

        private bool NotificationBoardExists(int id)
        {
            return _context.NotificationBoards.Any(e => e.Id == id);
        }
    }
}
