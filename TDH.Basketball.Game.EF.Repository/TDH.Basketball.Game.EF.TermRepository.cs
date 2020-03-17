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
    public class TermRepository : GenericRepository<Term>
    {
        public TermRepository(TDHDBContext context, ILogger<Term> logger) : base(context, logger)
        {

        }

        public async override Task<List<Term>> GetAsync()
        {

            return await _context.Terms
                            .Include(t =>t.CourtRentFee)
                            .ThenInclude(crf => crf.Centre)
                            .Where(t => t.IsActive == true)
                            .ToListAsync();
        }

        public async override Task<Term> GetAsync(int Id)
        {
            return await _context.Terms
                            .Include(t => t.CourtRentFee)
                            .ThenInclude(crf => crf.Centre)
                            .FirstOrDefaultAsync(t => t.Id == Id && t.IsActive == true);
        }

        public override async Task<bool> DeleteAsync(Term Term)
        {
            try
            {
                Term.IsActive = false;

                this._context.Update(Term);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public override async Task<bool> DeleteRangeAsync(List<Term> Terms)
        {
            try
            {
                Terms.ForEach(e => e.IsActive = false);
                this._context.UpdateRange(Terms);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

    }
}
