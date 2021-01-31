using System;
using System.Collections.Generic;
using Gather.Scripts.ProjectRoot;
using Sirenix.Utilities;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace Gather.Scripts.Unity.Stage
{
    public class ScoreManager:IInitializable, IDisposable
    {
        public Dictionary<int, int> PlayerScoreTable => _playerScoreTable;
        private readonly FieldObjectStateNotificator _fieldObjectStateNotificator;
        private readonly IPlayerProvider _playerProvider;
        private CompositeDisposable _disposable = new CompositeDisposable();
        private Dictionary<int,int> _playerScoreTable = new Dictionary<int,int>();

        public ScoreManager(FieldObjectStateNotificator fieldObjectStateNotificator, IPlayerProvider playerProvider)
        {
            _fieldObjectStateNotificator = fieldObjectStateNotificator;
            _playerProvider = playerProvider;
        }

        public void Initialize()
        {
            Debug.Log("-ssssssss");
            _playerProvider.GetCurrentPlayers().ForEach(x =>
            {
                _playerScoreTable[x.ID] = 0;
            });
            
            _fieldObjectStateNotificator.DestructionObjectAsObservable.Subscribe(x =>
            {
                // ランダム
                _playerScoreTable[x.ID] += 10;
                Debug.Log(x.ID.ToString() + ": " + _playerScoreTable[x.ID]);
            }).AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }

    }
}
