using System;
using Gather.Scripts.Domain.Data;
using Gather.Scripts.FieldObjectComponent;
using Gather.Scripts.ProjectRoot;
using UniRx;
using UnityEngine;
using VContainer;

namespace Gather.Scripts.Unity.Lobby.Object
{
    public enum ChangeType
    {
        Add,
        Remove
    }
    // ちゃんとInteractableObjectみたいなの作った方が良い
    public class PlayerCountChanger : MonoBehaviour, IDestructibleObject, IPlayerChangeNotificator
    {
        private IPlayerManager _playerManager;

        [Inject]
        public void Build(IPlayerManager playerManager)
        {
            _playerManager = playerManager;
        }
        

        [SerializeField] private ChangeType type;
        Subject<int> _subject = new Subject<int>();
        
        // Start is called before the first frame update
        void Start()
        {
        }

        public void ApplyDamage(AttackData attackData)
        {
            _subject.OnNext(type == ChangeType.Add ? 1 : -1);
        }

        public void Setup(FieldObjectStateNotificator fieldObjectStateNotificator)
        {
        }

        public IObservable<int> ChangePlayerCountAsObservable()
        {
            return _subject;
        }

        private void OnDestroy()
        {
            _subject?.Dispose();
        }
    }
}
