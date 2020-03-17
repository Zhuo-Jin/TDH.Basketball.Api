using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDH.Basketball.Game.EF.Core.EntityClasses;

namespace TDH.Basketball.Game.EF.Manager.Interface
{
    public interface ICourtRentFeeManager
    {
        Task<List<CourtRentFee>> GetAllFeesAsync();

        Task<CourtRentFee> GetFeeByIdAsync(int Id);


        Task<bool> AddOrUpdateFeeAsync(CourtRentFee Fee);

    }
}
