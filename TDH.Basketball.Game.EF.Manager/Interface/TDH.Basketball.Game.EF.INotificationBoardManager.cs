using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDH.Basketball.Game.EF.Core.EntityClasses;

namespace TDH.Basketball.Game.EF.Manager.Interface
{
    public interface INotificationBoardManager
    {
        Task<List<NotificationBoard>> GetAllNotificationBoardsAsync();

        Task<List<NotificationBoard>> GetAllReleasedNotificationBoardsAsync();

        Task<NotificationBoard> GetNotificationBoardByIdAsync(int Id);
        Task<bool> AddOrUpdateNotificationBoardAsync(NotificationBoard NotificationBoard);

        Task<bool> RemoveNotificationBoardAsync(NotificationBoard NotificationBoard);

    }
}
