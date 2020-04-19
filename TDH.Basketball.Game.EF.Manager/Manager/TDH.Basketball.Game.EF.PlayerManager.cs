using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDH.Basketball.Game.EF.Core.EntityClasses;
using TDH.Basketball.Game.EF.Manager.Interface;
using TDH.Basketball.Game.EF.Manager.Util;
using TDH.Basketball.Game.EF.Repository;

namespace TDH.Basketball.Game.EF.Manager.Manager
{
    public class PlayerManager : IPlayerManager
    {
        protected readonly IGenericRepository<Player> _playerRepository;
        protected readonly ILogger<Player> _logger;
        public PlayerManager(IGenericRepository<Player> playerRepository, ILogger<Player> logger)
        {
            _playerRepository = playerRepository;
            _logger = logger;
        }
        public async Task<bool> AddOrUpdatePlayerAsync(Player Player)
        {
            var player = _playerRepository.GetAsync(Player.Id);
            if (player == null)
            {
                Player.Password = Utils.GetSHA256Hash(Player.Password);
                return !(await _playerRepository.CreateAsync(Player) is null);
            }
            else {
                return await _playerRepository.UpdateAsync(Player.Id, Player);
            }
        }

        public async Task<IEnumerable<Player>> GetAllPlayersAsync()
        {
            return await _playerRepository.GetAsync();
        }

        public async Task<Player> GetPlayerByEmailAsync(string Email)
        {
            var allplayers = await _playerRepository.GetByExtensionFuncAsync(Email,
                    async eml => 
                         (await _playerRepository.GetAsync()).Where(p => p.Email == eml)?.ToList()
                );

            return allplayers.SingleOrDefault();
        }

        public async Task<Player> GetPlayerByIdAsync(int Id)
        {
            return await _playerRepository.GetAsync(Id);
        }

        public async Task<IEnumerable<Player>> GetPlayerByNickNameAsync(string Name)
        {
            return await _playerRepository.GetByExtensionFuncAsync(Name,
                    async name =>
                         (await _playerRepository.GetAsync()).Where(p => p.NickName == name)?.ToList()
                );
        }

        public async Task<bool> RemovePlayerAsync(Player Player)
        {
            return await _playerRepository.DeleteAsync(Player);
        }

        public async Task<bool> UpdatePlayerPasswordAsync(int PlayerId,  string Password)
        {
            var player = await _playerRepository.GetAsync(PlayerId);

            if (player != null)
            {
                player.Password = Utils.GetSHA256Hash(Password);
                return await _playerRepository.UpdateAsync(PlayerId, player);
            }
            else {
                _logger.LogError($"no player found for id {PlayerId.ToString()}");
                return false;
            }
            
        }
    }
}
