using UnityEngine;

namespace Gather.Scripts.Domain.Data
{
    public class AttackData
    {
        public int Power { get; }
        public PlayerData PlayerData { get; }

        public AttackData(int power, PlayerData playerData)
        {
            Power = power;
            PlayerData = playerData;
        }
    }
}
