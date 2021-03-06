﻿using Microsoft.Extensions.Logging;
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
    public class EventRepository : GenericRepository<Event>
    {
        public EventRepository(TDHDBContext context, ILogger<Event> logger) : base(context, logger)
        {

        }

        public override async Task<bool> DeleteAsync(Event Event)
        {
            try
            {
                Event.IsActive = false;

                this._context.Update(Event);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public override async Task<bool> DeleteRangeAsync(List<Event> Events)
        {
            try
            {
                Events.ForEach(e => e.IsActive = false);
                this._context.UpdateRange(Events);

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
