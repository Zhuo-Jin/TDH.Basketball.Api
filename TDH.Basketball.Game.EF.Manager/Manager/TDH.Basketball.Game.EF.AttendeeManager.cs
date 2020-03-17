using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDH.Basketball.Game.EF.Core.EntityClasses;
using TDH.Basketball.Game.EF.Manager.Interface;
using TDH.Basketball.Game.EF.Manager.Util;
using TDH.Basketball.Game.EF.Repository;

namespace TDH.Basketball.Game.EF.Manager.Manager
{
    public class AttendeeManager : IAttendeeManager
    {
        protected readonly IGenericRepository<Attendee> _attendeeRepository;
        protected readonly ILogger<Attendee> _logger;

        public AttendeeManager(IGenericRepository<Attendee> attendeeRepository, ILogger<Attendee> logger)
        {
            _attendeeRepository = attendeeRepository;
            _logger = logger;

        }
        public async Task<bool> AddOrUpdateAttendeeAsync(Attendee Attendee)
        {
            var dbAttendee = await _attendeeRepository.GetAsync(Attendee.Id);

            if (dbAttendee == null)
            {
                // add 
                Attendee.PaymentCode = Utils.GetPaymentCode(Attendee.PlayerId.ToString() + Attendee.Event.Id.ToString());
                return !(await _attendeeRepository.CreateAsync(Attendee) is null);
            }
            else { 
                return await _attendeeRepository.UpdateAsync(Attendee.Id, Attendee);
            }
        }

        public async Task<List<Attendee>> GetAllAttendeesByEventIdAsync(int EventId)
        {
            var allAttendee = await _attendeeRepository.GetAsync();

            return allAttendee.Where(a => a.EventId == EventId).ToList();

        }

        public async Task<Attendee> GetAttendeeByIdAsync(int Id)
        {
            return await _attendeeRepository.GetAsync(Id);
        }

        public async Task<bool> RemoveAttendeeAsync(Attendee Attendee)
        {
            return await _attendeeRepository.DeleteAsync(Attendee);
        }
    }
}
