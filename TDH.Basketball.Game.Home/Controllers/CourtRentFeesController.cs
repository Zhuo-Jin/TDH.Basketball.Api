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
    [Route("api/RentFee")]
    [ApiController]
    public class CourtRentFeesController : ControllerBase
    {

        private readonly ICourtRentFeeManager _courtRentFeeManager;
        public CourtRentFeesController(ICourtRentFeeManager courtRentFeeManager)
        {
            _courtRentFeeManager = courtRentFeeManager;
        }

        // GET: api/CourtRentFees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourtRentFee>>> GetCourtRentFees()
        {
            return Ok(await _courtRentFeeManager.GetAllFeesAsync());
        }

        // GET: api/CourtRentFees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourtRentFee>> GetCourtRentFee(int id)
        {
            var courtRentFee = await _courtRentFeeManager.GetFeeByIdAsync(id);

            if (courtRentFee == null)
            {
                return NotFound();
            }

            return courtRentFee;
        }



        // POST: api/CourtRentFees
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("upsert")]
        public async Task<ActionResult<bool>> PostCourtRentFee(CourtRentFee courtRentFee)
        {
            return await _courtRentFeeManager.AddOrUpdateFeeAsync(courtRentFee);

        }
    }
}
