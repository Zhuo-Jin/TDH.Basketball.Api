using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDH.Basketball.Game.EF.Core.EntityClasses;

namespace TDH.Basketball.Game.EF.Manager.Interface
{
    public interface IAttendeeManager
    {

        Task<List<Attendee>> GetAllAttendeesByEventIdAsync(int EventId);

        Task<Attendee> GetAttendeeByIdAsync(int Id);
        Task<bool> AddOrUpdateAttendeeAsync(Attendee Attendee);
        Task<bool> RemoveAttendeeAsync(Attendee Attendee);

    }
}
