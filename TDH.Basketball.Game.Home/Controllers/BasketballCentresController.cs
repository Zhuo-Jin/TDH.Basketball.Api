using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TDH.Basketball.Game.EF.Core;
using TDH.Basketball.Game.EF.Core.EntityClasses;
using TDH.Basketball.Game.EF.Manager.Interface;

namespace TDH.Basketball.Game.Home.Controllers
{
    [Route("api/Centres")]
    [ApiController]
    public class BasketballCentresController : ControllerBase
    {
        private readonly IBasketballCentreManager _basketballCentreManager;
        public BasketballCentresController(IBasketballCentreManager basketballCentreManager)
        {
            _basketballCentreManager = basketballCentreManager;
        }

        // GET: api/BasketballCentres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasketballCentre>>> GetBasketballCentres()
        {
            return Ok(await _basketballCentreManager.GetAllCentresAsync());
        }

        // GET: api/BasketballCentres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BasketballCentre>> GetBasketballCentre(int id)
        {
            var centre = await _basketballCentreManager.GetCentreByIdAsync(id);

            if (centre == null)
            {
                return NotFound();
            }

            return centre;
        }



        // POST: api/BasketballCentres
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("upsert")]
        public async Task<ActionResult<bool>> PostBasketballCentre(BasketballCentre basketballCentre)
        {

            if (await _basketballCentreManager.AddOrUpdateCentreAsync(basketballCentre))
            {
                return Ok(true);
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError); ;
            }
        }

    }
}
