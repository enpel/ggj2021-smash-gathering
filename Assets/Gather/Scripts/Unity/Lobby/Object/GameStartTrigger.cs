using System;
using Gather.Scripts.Domain.Data;
using Gather.Scripts.Unity;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Gather.Scripts.Lobby.Object
{
    [RequireComponent(typeof(Collider))]
    public class GameStartTrigger : MonoBehaviour, IPlayerAlreadyNotificator
    {
        Subject<Tuple<PlayerData, bool>> _isAlreadPlayerAsObservable = new Subject<Tuple<PlayerData, bool>>();
        
        // Start is called before the first frame update
        void Start()
        {
            this.OnTriggerEnterAsObservable()
                .Do(x => Debug.Log(x.name))
                .Where(x => x.CompareTag("Player"))
                .Subscribe(x => _isAlreadPlayerAsObservable.OnNext(new Tuple<PlayerData, bool>(new PlayerData("player", 0), true)))
                .AddTo(this);

            _isAlreadPlayerAsObservable.AddTo(this);
        }

        public IObservable<Tuple<PlayerData, bool>> IsAlreadyPlayerAsObservable()
        {
            return _isAlreadPlayerAsObservable;
        }
    }
}
