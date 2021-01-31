using UnityEngine;

namespace Gather.Scripts.Domain.Data
{
    public class PlayerData
    {
        public string Name { get; }
        public int ID { get; }

        public PlayerData(string name, int id)
        {
            Name = name;
            ID = id;
        }
    }
}
