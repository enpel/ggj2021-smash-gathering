using Gather.Scripts.Domain.Data;
using UnityEngine;

namespace Gather.Scripts.Unity.Basket
{
    public class Basket : MonoBehaviour
    {
        private PlayerData _playerData;
        public void SetPlayerData(PlayerData playerData)
        {
            _playerData = playerData;
        }

        public void Purge()
        {
        }
    }
}
