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
    public class CourtRentFeeRepository : GenericRepository<CourtRentFee>
    {

        public CourtRentFeeRepository(TDHDBContext context, ILogger<CourtRentFee> logger) : base(context, logger)
        {

        }

        public async override Task<IEnumerable<CourtRentFee>> GetAsync()
        {

            return await _context.CourtRentFees
                            .Include(c =>　c.Centre)
                            .Include(c => c.CourtType)
                            .Where(t => t.IsCurrent)
                            .ToListAsync();
        }

        public async override Task<CourtRentFee> GetAsync(int Id)
        {
            var courtRentFee =  await _context.CourtRentFees
                            .Include(c => c.Centre)
                            .Include(c => c.CourtType)
                            .Where(t => t.IsCurrent)
                            .FirstOrDefaultAsync(t => t.Id == Id);

            if (courtRentFee != null)
                _context.Entry(courtRentFee).State = EntityState.Detached; // detached with no tracking

            return courtRentFee;
        }
    }
}
