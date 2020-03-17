using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDH.Basketball.Game.EF.Core;
using TDH.Basketball.Game.EF.Core.EntityClasses;

namespace TDH.Basketball.Game.EF.Repository
{
    public class BasketballCentreRepository : GenericRepository<BasketballCentre>
    {

        public BasketballCentreRepository(TDHDBContext context, ILogger<BasketballCentre> logger) : base(context, logger)
        {

        }
    }
}
