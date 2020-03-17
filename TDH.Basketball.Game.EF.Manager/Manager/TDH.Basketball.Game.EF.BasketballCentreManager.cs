using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDH.Basketball.Game.EF.Core.EntityClasses;
using TDH.Basketball.Game.EF.Manager.Interface;
using TDH.Basketball.Game.EF.Repository;

namespace TDH.Basketball.Game.EF.Manager.Manager
{
    public class BasketballCentreManager : IBasketballCentreManager
    {

        protected readonly IGenericRepository<BasketballCentre> _basketballCentreRepository;
        protected readonly ILogger<BasketballCentre> _logger;

        public BasketballCentreManager(IGenericRepository<BasketballCentre> basketballCentreRepository, ILogger<BasketballCentre> logger)
        {
            _basketballCentreRepository = basketballCentreRepository;
            _logger = logger;
        }

        public async Task<bool> AddOrUpdateCentreAsync(BasketballCentre Centre)
        {
            var dbCentre = await _basketballCentreRepository.GetAsync(Centre.Id);

            if (dbCentre == null)
            {
                // add 
                return !(await _basketballCentreRepository.CreateAsync(Centre) is null);
            }
            else
            {
                return await _basketballCentreRepository.UpdateAsync(Centre.Id, Centre);
            }
        }

        public async Task<List<BasketballCentre>> GetAllCentresAsync()
        {
            return await _basketballCentreRepository.GetAsync();
        }

        public async Task<BasketballCentre> GetCentreByIdAsync(int Id)
        {
            return await _basketballCentreRepository.GetAsync(Id);
        }
    }
}
