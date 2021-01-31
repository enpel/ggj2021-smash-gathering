using Gather.Scripts.Domain.Data;
using Gather.Scripts.ProjectRoot;

namespace Gather.Scripts.Unity
{
    public class MockPlayerProvider : IPlayerProvider
    {
        public PlayerData[] GetCurrentPlayers()
        {
            return new[]
            {
                new PlayerData("てすとさん1", 1),
                new PlayerData("てすとさん2", 2),
                new PlayerData("てすとさん3", 3),
                new PlayerData("てすとさん4", 4),
            };
        }
    }
}