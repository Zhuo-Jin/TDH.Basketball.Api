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
    public class TermManager : ITermManager
    {

        protected readonly IGenericRepository<Term> _termRepository;
        protected readonly IGenericRepository<Event> _eventRepository;
        protected readonly IGenericRepository<Attendee> _attendeeRepository;
        protected readonly IGenericRepository<Player> _playerRepository;
        protected readonly ILogger<Term> _logger;

        public TermManager(IGenericRepository<Term> genericRepository, 
                            IGenericRepository<Event> eventRepository , 
                            IGenericRepository<Attendee> attendeeRepository ,
                             IGenericRepository<Player> playerRepository,
                            ILogger<Term> logger)
        {
            _termRepository = genericRepository;
            _eventRepository = eventRepository;
            _attendeeRepository = attendeeRepository;
            _playerRepository = playerRepository;
            _logger = logger;

        }

    public async Task<bool> AddOrUpdateTermAsync(Term Term)
        {
            var term = await _termRepository.GetAsync(Term.Id);


            if (term == null)
            {
                // add 
                // need more code to add or remove event and attendee
                var termCreated = await _termRepository.CreateAsync(Term);
                return await CreateEventsBasedOnTermAsync(Term);
            }
            else {
                return await _termRepository.UpdateAsync(Term.Id, Term);
            }
        }

        public async Task<List<Term>> GetAllTermsAsync(DateTime Startdate, DateTime EndDate)
        {
            var allterms = await _termRepository.GetAsync();
            return allterms.Where(t => t.StartDateTime >= Startdate && t.EndDateTime <= EndDate).ToList();

        }

        public async Task<Term> GetTermByIdAsync(int Id)
        {
            return await _termRepository.GetAsync(Id);

        }
 

        public async Task<bool> RemoveTermAsync(Term Term)
        {
            var success = true;

            var events = (await _eventRepository.GetAsync()).Where(e => e.TermId == Term.Id);
            foreach (var gameEvent in events) {
                success &= await _attendeeRepository.DeleteRangeAsync((await _attendeeRepository.GetAsync()).Where(a => a.EventId == gameEvent.Id).ToList());
            }

            success &= await _eventRepository.DeleteRangeAsync(events.ToList());

            success &= await _termRepository.DeleteAsync(Term);

            return success;
        }

        private async Task<bool> CreateEventsBasedOnTermAsync(Term Term)
        {
            int gameNumber = 1;

            var success = true;

            for (DateTime date = Term.StartDateTime; date <= Term.EndDateTime; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Sunday)
                {
                    var gameEvent = await _eventRepository.CreateAsync(new Event() {
                        TermId = Term.Id,
                        EventName = $"Game {gameNumber++}",
                        EventDate = date,
                        IsActive = true
                    });

                    if (gameEvent != null)
                    {
                        success &= await CreateAttendeesBasedOnEventAsync(gameEvent, Term);
                    }
                    else {
                        return false;
                    }
                }
            }

            return success;
        }

        private async Task<bool> CreateAttendeesBasedOnEventAsync(Event Event, Term Term) {
            var permanents = (await _playerRepository.GetAsync()).Where(p => p.IsPermanent).ToList();
            var averageCost = Term.CourtRentFee.ChargeFee / permanents.Count();
            var attendees = permanents.Select(p => new Attendee()
            {
                EventId = Event.Id,
                PlayerId = p.Id,
                ReplacedPlayerId = 0, // to be added later
                PaymentCode = Utils.GetPaymentCode(p.Id.ToString() + Term.StartDateTime.ToString()),
                IsPermanent = true,
                FeeShared = averageCost,
                PaidDateTime = null
                

            }).ToList();


            return await _attendeeRepository.CreateRangeAsync(attendees);
        }
    }
}
