using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TDH.Basketball.Game.EF.Core;
using TDH.Basketball.Game.EF.Core.EntityClasses;
using System.Linq;

namespace TDH.Basketball.Game.EF.Repository
{
    // not implement at this moment may be used later

    public class AttendeeRepository : GenericRepository<Attendee>
    {

        public AttendeeRepository(TDHDBContext context, ILogger<Attendee> logger) : base(context, logger)
        {

        }

        public async override Task<List<Attendee>> GetAsync()
        {

            return await _context.Attendees
                            .Include(a => a.Player)
                            .Include(a => a.ReplacedPlayer)
                            .Include(a => a.Event)
                            .ToListAsync();
        }

        public async override Task<Attendee> GetAsync(int Id)
        {
            return await _context.Attendees
                            .Include(a => a.Player)
                            .Include(a => a.ReplacedPlayer)
                            .Include(a => a.Event)
                            .FirstOrDefaultAsync(a => a.Id == Id);
        }



    }
}
