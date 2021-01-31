using Gather.Scripts.Domain.Data;

namespace Gather.Scripts.ProjectRoot
{
    public interface IPlayerProvider
    {
        PlayerData[] GetCurrentPlayers();
    }
}
