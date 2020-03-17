using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TDH.Basketball.Game.EF.Core;
using TDH.Basketball.Game.EF.Core.EntityClasses;

namespace TDH.Basketball.Game.EF.Repository
{
    public class NotificationBoardRepository : GenericRepository<NotificationBoard>
    {
        public NotificationBoardRepository(TDHDBContext context, ILogger<NotificationBoard> logger) : base(context, logger)
        { 
        }
    }
}
