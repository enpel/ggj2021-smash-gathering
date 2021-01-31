using System;
using Gather.Scripts.Domain.Data;
using UniRx;
using UnityEngine;

namespace Gather.Scripts
{
    public class FieldObjectStateNotificator : IDisposable
    {
        public IObservable<PlayerData> DestructionObjectAsObservable => _subject;

        private Subject<PlayerData> _subject = new Subject<PlayerData>();

        public void Destruction(PlayerData destructionPlayer)
        {
            Debug.Log("----" + destructionPlayer.ID);
            _subject.OnNext(destructionPlayer);
        }

        public void Dispose()
        {
            _subject?.Dispose();
        }
    }
}
