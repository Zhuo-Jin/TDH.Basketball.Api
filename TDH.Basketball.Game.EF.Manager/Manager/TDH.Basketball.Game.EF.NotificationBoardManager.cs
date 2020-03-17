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
    public class NotificationBoardManager : INotificationBoardManager
    {


        protected readonly IGenericRepository<NotificationBoard> _notificationBoardRepository;
        protected readonly ILogger<NotificationBoard> _logger;

        public NotificationBoardManager(IGenericRepository<NotificationBoard> notificationBoardRepository, ILogger<NotificationBoard> logger)
        {
            _notificationBoardRepository = notificationBoardRepository;
            _logger = logger;

        }
        public async Task<bool> AddOrUpdateNotificationBoardAsync(NotificationBoard NotificationBoard)
        {
            var dbNotificationBoard = await _notificationBoardRepository.GetAsync(NotificationBoard.Id);

            if (dbNotificationBoard == null)
            {
                // add 
                return !(await _notificationBoardRepository.CreateAsync(NotificationBoard) is null);
            }
            else
            {
                return await _notificationBoardRepository.UpdateAsync(NotificationBoard.Id, NotificationBoard);
            }
        }

        public async Task<List<NotificationBoard>> GetAllNotificationBoardsAsync()
        {
            return (await _notificationBoardRepository.GetAsync()).Where(n => n.IsActive).ToList();
        }

        public async Task<List<NotificationBoard>> GetAllReleasedNotificationBoardsAsync()
        {
            return (await _notificationBoardRepository.GetAsync()).Where(n => n.IsActive && n.ReleaseDateTime <= DateTime.Now ).ToList();
        }

        public async Task<NotificationBoard> GetNotificationBoardByIdAsync(int Id)
        {
            return await _notificationBoardRepository.GetAsync(Id);
        }

        public async Task<bool> RemoveNotificationBoardAsync(NotificationBoard NotificationBoard)
        {
            return await _notificationBoardRepository.DeleteAsync(NotificationBoard);
        }


    }
}
