using System.Linq;
using UnityEngine;

namespace Gather.Scripts.Unity
{
    public class StageMapSetting : MonoBehaviour
    {
        [SerializeField] private Transform[] _playerSpawnPoints;

        public Transform GetPlayerSpawnPoint()
        {
            return _playerSpawnPoints.First();
        }
        
        public Transform[] GetPlayerSpawnPoints()
        {
            return _playerSpawnPoints;
        }
    }
}
