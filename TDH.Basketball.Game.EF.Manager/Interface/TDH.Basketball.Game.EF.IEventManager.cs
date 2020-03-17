using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDH.Basketball.Game.EF.Core.EntityClasses;

namespace TDH.Basketball.Game.EF.Manager.Interface
{
    public interface IEventManager
    {

        Task<List<Event>> GetAllEventsByTermIdAsync(int TermId);

        Task<Event> GetEventByIdAsync(int Id);

        Task<bool> AddOrUpdateEventAsync(Event Event);
        Task<bool> RemoveEventAsync(Event Event);
    }
}
