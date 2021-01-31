using Gather.Scripts.Domain.Data;
using Gather.Scripts.Unity.Stage;
using UnityEngine;

namespace Gather.Scripts.Unity.Factory
{
    public interface IPlayerFactory
    {
        Player.Player Create(PlayerData playerData);
    }
    
    public class PlayerFactory : IPlayerFactory
    {
        private readonly GameObject _playerPrefab;

        public PlayerFactory(GameObject playerPrefab)
        {
            _playerPrefab = playerPrefab;
        }

        public Player.Player Create(PlayerData playerData)
        {
            var player = GameObject.Instantiate(_playerPrefab).GetComponent<Player.Player>();
            player.Initialize(playerData);
            return player;
        }
    }
    
    
    public class PlayerFromHolderFactory : IPlayerFactory
    {
        private readonly GameObject _playerPrefab;

        public PlayerFromHolderFactory(StagePrefabHolder holder)
        {
            _playerPrefab = holder.PlayerPrefab;
        }

        public Player.Player Create(PlayerData playerData)
        {
            var player = GameObject.Instantiate(_playerPrefab).GetComponent<Player.Player>();
            player.Initialize(playerData);
            return player;
        }
    }
}
