using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TDH.Basketball.Game.EF.Core;
using TDH.Basketball.Game.EF.Core.EntityClasses;
using TDH.Basketball.Game.EF.Manager.Interface;

namespace TDH.Basketball.Game.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeesController : ControllerBase
    {
        private readonly TDHDBContext _context;
        private readonly IAttendeeManager _attendeeManager;
        public AttendeesController(TDHDBContext context, IAttendeeManager attendeeManager)
        {
            _context = context;
            _attendeeManager = attendeeManager;
        }


        // GET: api/Attendees/5
        [HttpGet("ByEvent/{id}")]
        public async Task<ActionResult<Attendee>> ByEvent(int? EventId)
        {
            if (EventId == null)
            {
                return BadRequest();
            }

            var attendees = await _attendeeManager.GetAllAttendeesByEventIdAsync(EventId ?? 0);

            if (attendees == null && !attendees.Any())
            {
                return NotFound();
            }


            return Ok(attendees);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Upsert(Attendee attendee)
        {
            if (await _attendeeManager.AddOrUpdateAttendeeAsync(attendee))
                return Ok(true);
            else {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE: api/Attendees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Attendee>> DeleteAttendee(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var attendee = await _attendeeManager.GetAttendeeByIdAsync(id ?? 0);

            if (attendee == null)
            {
                return NotFound();
            }



            if (await _attendeeManager.RemoveAttendeeAsync(attendee))
                return Ok(true);
            else
                return new StatusCodeResult(StatusCodes.Status500InternalServerError); ;
        }

        private bool AttendeeExists(int id)
        {
            return _context.Attendees.Any(e => e.Id == id);
        }
    }
}
