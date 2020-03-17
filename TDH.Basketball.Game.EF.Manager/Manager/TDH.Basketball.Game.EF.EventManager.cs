using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDH.Basketball.Game.EF.Core.EntityClasses;
using TDH.Basketball.Game.EF.Manager.Interface;
using TDH.Basketball.Game.EF.Repository;

namespace TDH.Basketball.Game.EF.Manager.Manager
{
    public class EventManager : IEventManager
    {

        protected readonly IGenericRepository<Event> _eventRepository;
        protected readonly ILogger<Event> _logger;

        public EventManager(IGenericRepository<Event> eventRepository, ILogger<Event> logger)
        {
            _eventRepository = eventRepository;
            _logger = logger;

        }
        public async Task<bool> AddOrUpdateEventAsync(Event Event)
        {
            var dbEvent = _eventRepository.GetAsync(Event.Id);

            if (dbEvent == null)
            {
                return !(await _eventRepository.CreateAsync(Event) is null);
            }
            else {
                return await _eventRepository.UpdateAsync(Event.Id, Event);
            }
        }

        public async Task<List<Event>> GetAllEventsByTermIdAsync(int TermId)
        {
            return (await _eventRepository.GetAsync()).Where(e => e.TermId == TermId && e.IsActive).ToList();
        }

        public async Task<Event> GetEventByIdAsync(int Id)
        {
            return await _eventRepository.GetAsync(Id);
        }


        public async Task<bool> RemoveEventAsync(Event Event)
        {
            return await _eventRepository.DeleteAsync(Event);
        }
    }
}
