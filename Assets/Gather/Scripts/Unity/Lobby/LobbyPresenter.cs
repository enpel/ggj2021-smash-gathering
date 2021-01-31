using System;
using System.Collections.Generic;
using System.Linq;
using Gather.Scripts.Domain.Data;
using Gather.Scripts.ProjectRoot;
using Gather.Scripts.Unity;
using Gather.Scripts.Unity.Factory;
using Gather.Scripts.Unity.Lobby.Object;
using Sirenix.Utilities;
using UniRx;
using UnityEngine;
using VContainer.Unity;
using Random = UnityEngine.Random;

namespace Gather.Scripts.Lobby
{
    public class LobbyPresenter : IStartable, IDisposable
    {
        private Transform spawnPoint;
        private readonly IPlayerFactory _playerFactory;
        private readonly IPlayerProvider _playerProvider;
        private readonly IPlayerManager _playerManager;
        private CompositeDisposable _disposable = new CompositeDisposable();
        
        List<Player.Player> _playerList = new List<Player.Player>();

        public LobbyPresenter(IPlayerFactory playerFactory, IPlayerProvider playerProvider, IPlayerManager playerManager)
        {
            _playerFactory = playerFactory;
            _playerProvider = playerProvider;
            _playerManager = playerManager;
        }
        
        public void Start()
        {
            var players = _playerProvider.GetCurrentPlayers();

            var notificators = GameObject.FindObjectsOfType<PlayerCountChanger>()
                .Select(x => x.GetComponent<IPlayerChangeNotificator>());
            
            players.ForEach(CreatePlayer);


            notificators.Select(x => x.ChangePlayerCountAsObservable())
                .Merge()
                .Subscribe(x =>
                {
                    if (x == 1)
                    {
                        _playerManager.AddPlayer();
                    }
                    else
                    {
                        _playerManager.RemoveLastPlayer();
                    }
                }).AddTo(_disposable);

            _playerManager.AddPlayerAsObservable()
                .Subscribe(CreatePlayer)
                .AddTo(_disposable);
            
            _playerManager.RemovePlayerAsObservable()
                .Subscribe(RemovePlayer)
                .AddTo(_disposable);

        }

        private void CreatePlayer(PlayerData playerData)
        {
            var clone = _playerFactory.Create(playerData);
            clone.transform.position = new Vector3(Random.Range(-2,2), 0, Random.Range(-2,2));
            clone.transform.rotation = Quaternion.identity;
            
            _playerList.Add(clone);
        }

        private void RemovePlayer(PlayerData playerData)
        {
            var target = _playerList.Find(x => x.PlayerData.ID == playerData.ID);
            _playerList.Remove(target);
            
            GameObject.Destroy(target.gameObject);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}
