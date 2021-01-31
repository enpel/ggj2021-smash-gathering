using Gather.Scripts.Lobby;
using Gather.Scripts.Lobby.Object;
using Gather.Scripts.Unity;
using Gather.Scripts.Unity.Factory;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class LobbyLifetimeScope : LifetimeScope
{
    [SerializeField] private GameStartTrigger _gameStartTrigger;
    [SerializeField] private GameObject _playerPrefab;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<LobbyPresenter>(Lifetime.Scoped);
        builder.RegisterEntryPoint<GameStartPresenter>(Lifetime.Scoped);
        builder.RegisterComponent<IPlayerAlreadyNotificator>(_gameStartTrigger);
        builder.RegisterInstance(new PlayerFactory(_playerPrefab)).AsImplementedInterfaces();
    }
}
