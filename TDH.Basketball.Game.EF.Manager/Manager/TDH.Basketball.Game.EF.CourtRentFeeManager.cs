using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDH.Basketball.Game.EF.Core.EntityClasses;
using TDH.Basketball.Game.EF.Manager.Interface;
using TDH.Basketball.Game.EF.Repository;

namespace TDH.Basketball.Game.EF.Manager.Manager
{
    public class CourtRentFeeManager : ICourtRentFeeManager
    {

        protected readonly IGenericRepository<CourtRentFee> _courtRentFeeRepository;
       

        protected readonly ILogger<CourtRentFee> _logger;

        public CourtRentFeeManager( IGenericRepository<CourtRentFee> courtRentFeeRepository,
                                     ILogger<CourtRentFee> logger)
        {
           
            _courtRentFeeRepository = courtRentFeeRepository;
            _logger = logger;
        }

        public async Task<bool> AddOrUpdateFeeAsync(CourtRentFee Fee)
        {
            var dbCourtRentFee = await _courtRentFeeRepository.GetAsync(Fee.Id);
            var success = true;

            if (!Fee.IsCurrent)
            {
                _logger.LogError($"New Add/Update fee must be current (Set IsCurrent flag as true) for basketball centre {Fee.CentreId}");
                return false;
            }

            success &= await UpdateAllAsPassedFee(Fee.CentreId);

            if (dbCourtRentFee == null)
            {
                // add 
                return success && !(await _courtRentFeeRepository.CreateAsync(Fee) is null);
            }
            else
            {
                return await _courtRentFeeRepository.UpdateAsync(Fee.Id, Fee);
            }
        }

        public async Task<List<CourtRentFee>> GetAllFeesAsync()
        {
            return await _courtRentFeeRepository.GetAsync();
        }

        public async Task<CourtRentFee> GetFeeByIdAsync(int Id)
        {
            return await _courtRentFeeRepository.GetAsync(Id);
        }

        private async Task<bool> UpdateAllAsPassedFee(int CentreId)
        {
            var allCourtFees = (await _courtRentFeeRepository.GetAsync()).Where(f => f.CentreId == CentreId && f.IsCurrent).ToList();

            var success = true;

            allCourtFees.ForEach(async f =>
                                         {  
                                             f.IsCurrent = false;
                                             success &= await _courtRentFeeRepository.UpdateAsync(f.Id, f);
                                         });

            return success;
        }
    }
}
