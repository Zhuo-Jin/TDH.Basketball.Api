using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDH.Basketball.Game.EF.Core.EntityClasses;

namespace TDH.Basketball.Game.EF.Manager.Interface
{
    public interface IPlayerManager
    {
        Task<List<Player>> GetAllPlayersAsync();

        Task<Player> GetPlayerByIdAsync(int Id);
        Task<List<Player>> GetPlayerByNickNameAsync(string Name);

        Task<Player> GetPlayerByEmailAsync(string Email);
        Task<bool> AddOrUpdatePlayerAsync(Player Player);
        Task<bool> RemovePlayerAsync(Player Player);

        Task<bool> UpdatePlayerPasswordAsync(int PlayerId, string Password);



    }
}
