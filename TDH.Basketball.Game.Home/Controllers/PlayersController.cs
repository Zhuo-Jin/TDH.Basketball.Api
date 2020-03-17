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
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerManager _playermManager;

        public PlayersController(IPlayerManager playermManager)
        {
            _playermManager = playermManager;
        }

        // GET: api/Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            return await _playermManager.GetAllPlayersAsync();
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = await _playermManager.GetPlayerByIdAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }



        // POST: api/Players
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("upsert")]
        public async Task<ActionResult<Player>> UpsertPlayer(Player player)
        {
            if (await _playermManager.AddOrUpdatePlayerAsync(player))
            {
                return Ok(true);
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError); ;
            }
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Player>> DeletePlayer(int id)
        {
            var player = await _playermManager.GetPlayerByIdAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            if (await _playermManager.RemovePlayerAsync(player))
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
