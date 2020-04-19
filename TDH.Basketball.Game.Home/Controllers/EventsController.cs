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
    public class EventsController : ControllerBase
    {

        private readonly IEventManager _eventManager;
        public EventsController(IEventManager eventManager)
        {
            _eventManager = eventManager;
        }

        // GET: api/Events
        [HttpGet("ByTerm/{id}")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEventsByTermId(int id)
        {
            return await _eventManager.GetAllEventsByTermIdAsync(id);
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            return await _eventManager.GetEventByIdAsync(id);
  
        }


        // POST: api/Events
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("upsert")]
        public async Task<ActionResult<bool>> Upsert(Event Event)
        {
            if (await _eventManager.AddOrUpdateEventAsync(Event))
                return Ok(true);
            else
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Event>> DeleteEvent(int id)
        {
            var ballEvent = await _eventManager.GetEventByIdAsync(id);
            if (ballEvent == null)
            {
                return NotFound();
            }

            if (await _eventManager.RemoveEventAsync(ballEvent))
            {
                return Ok(true);
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError); ;
            }
        }


    }
}
