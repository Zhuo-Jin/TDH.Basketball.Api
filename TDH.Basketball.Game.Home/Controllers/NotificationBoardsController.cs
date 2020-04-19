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
    public class NotificationBoardsController : ControllerBase
    {
        private readonly INotificationBoardManager _notificationBoardManager;

        public NotificationBoardsController(INotificationBoardManager notificationBoardManager)
        {
            _notificationBoardManager = notificationBoardManager;
        }

        // GET: api/NotificationBoards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificationBoard>>> GetNotificationBoards()
        {
            return await _notificationBoardManager.GetAllReleasedNotificationBoardsAsync();
        }

        // GET: api/NotificationBoards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NotificationBoard>> GetNotificationBoard(int id)
        {
            var notificationBoard = await _notificationBoardManager.GetNotificationBoardByIdAsync(id);

            if (notificationBoard == null)
            {
                return NotFound();
            }

            return notificationBoard;
        }



        // POST: api/NotificationBoards
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("upsert")]
        public async Task<ActionResult<bool>> PostNotificationBoard(NotificationBoard notificationBoard)
        {
            if (await _notificationBoardManager.AddOrUpdateNotificationBoardAsync(notificationBoard))
            {
                return Ok(true);
            }
            else {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError); 
            }
        }

        // DELETE: api/NotificationBoards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NotificationBoard>> DeleteNotificationBoard(int id)
        {
            var notificationBoard = await _notificationBoardManager.GetNotificationBoardByIdAsync(id);
            if (notificationBoard == null)
            {
                return NotFound();
            }

            if (!await _notificationBoardManager.RemoveNotificationBoardAsync(notificationBoard))
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
 
            return notificationBoard;
        }

        
    }
}
