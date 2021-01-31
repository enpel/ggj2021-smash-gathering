using VContainer.Unity;

namespace Gather.Scripts.ProjectRoot
{
    public class GameInitializer : IInitializable
    {
        private readonly IPlayerManager _playerManager;

        public GameInitializer(IPlayerManager playerManager)
        {
            _playerManager = playerManager;
        }

        public void Initialize()
        {
            _playerManager.AddPlayer();
        }
    }
}
