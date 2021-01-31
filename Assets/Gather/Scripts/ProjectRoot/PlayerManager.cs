using System;
using System.Collections.Generic;
using System.Linq;
using Gather.Scripts.Domain.Data;
using UniRx;

namespace Gather.Scripts.ProjectRoot
{
    public class PlayerManager:IPlayerProvider, IPlayerManager, IDisposable
    {
        private List<PlayerData> _players = new List<PlayerData>();
        private Subject<PlayerData> _addSubject = new Subject<PlayerData>();
        private Subject<PlayerData> _removeSubject = new Subject<PlayerData>();
        private CompositeDisposable _disposable = new CompositeDisposable();

        public PlayerManager()
        {
            _addSubject.AddTo(_disposable);
            _removeSubject.AddTo(_disposable);
        }
        
        public void AddPlayer()
        {
            var addPlayer = new PlayerData("", _players.Count);
            _players.Add(addPlayer);
            _addSubject.OnNext(addPlayer);
        }

        public void RemoveLastPlayer()
        {
            if (_players.Count - 1 < 1) return;
            var removedPlayer = _players.Last();
            _players.Remove(removedPlayer);
            _removeSubject.OnNext(removedPlayer);
        }

        public IObservable<PlayerData> AddPlayerAsObservable()
        {
            return _addSubject;
        }

        public IObservable<PlayerData> RemovePlayerAsObservable()
        {
            return _removeSubject;
        }

        public PlayerData[] GetCurrentPlayers()
        {
            return _players.ToArray();
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}
