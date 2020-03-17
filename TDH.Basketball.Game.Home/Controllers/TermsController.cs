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
    [Route("api/[controller]")]
    [ApiController]
    public class TermsController : ControllerBase
    {
        private readonly ITermManager _termManager;
        public TermsController( ITermManager termManager)
        {
            _termManager = termManager;
        }

        // GET: api/Terms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Term>>> GetTerms()
        {
            return await _termManager.GetAllTermsAsync(DateTime.MinValue, DateTime.MaxValue);
        }

        // GET: api/Terms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Term>> GetTerm(int id)
        {
            var term = await _termManager.GetTermByIdAsync(id);

            if (term == null)
            {
                return NotFound();
            }

            return term;
        }


        // POST: api/Terms
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("upsert")]
        public async Task<ActionResult<bool>> UpsertTerm(Term term)
        {
          
            if (await _termManager.AddOrUpdateTermAsync(term))
            {
                return Ok(true);
            }
            else {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError); ;
            }
        }

        // DELETE: api/Terms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteTerm(int id)
        {
            var term = await _termManager.GetTermByIdAsync(id);
            if (term == null)
            {
                return NotFound();
            }

            if (await _termManager.RemoveTermAsync(term))
            {
                return Ok(true);
            }
            else {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError); ;
            }
        }
    }
}
