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
    public class PlayerRepository : GenericRepository <Player>
    {
        public PlayerRepository(TDHDBContext context, ILogger<Player> logger) : base (context, logger)
        { 
        
        }

        public override async Task<bool> DeleteAsync(Player Player)
        {
            try
            {
                Player.IsActive = false;

                this._context.Update(Player);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

    }
}
