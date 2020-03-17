using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDH.Basketball.Game.EF.Core.EntityClasses;

namespace TDH.Basketball.Game.EF.Manager.Interface
{
    public interface IBasketballCentreManager
    {
        Task<List<BasketballCentre>> GetAllCentresAsync();

        Task<BasketballCentre> GetCentreByIdAsync(int Id);


        Task<bool> AddOrUpdateCentreAsync(BasketballCentre Centre);

    }
}
