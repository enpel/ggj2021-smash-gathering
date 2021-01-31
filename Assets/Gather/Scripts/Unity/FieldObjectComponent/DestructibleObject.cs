using System;
using Gather.Scripts.Domain.Data;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using VContainer;

namespace Gather.Scripts.FieldObjectComponent
{
    [Serializable]
    public class DestructibleObjectParameter
    {
        public int Hp;

        public DestructibleObjectParameter(int hp)
        {
            Hp = hp;
        }
    }
    public class DestructibleObject : MonoBehaviour, IDestructibleObject
    {
        [SerializeField]
        private readonly DestructibleObjectParameter _initializeParameter = new DestructibleObjectParameter(3);
        private DestructibleObjectParameter _currentParameter;
        private AttackData _lastAttackData;
        private FieldObjectStateNotificator _fieldObjectStateNotificator;

        public void Setup(FieldObjectStateNotificator fieldObjectStateNotificator)
        {
            _fieldObjectStateNotificator = fieldObjectStateNotificator;
        }

        private void Awake()
        {
            _currentParameter = _initializeParameter;

            this.LateUpdateAsObservable()
                .Where(x => _currentParameter.Hp <= 0)
                .Subscribe(x =>
                {
                    _fieldObjectStateNotificator.Destruction(_lastAttackData.PlayerData);
                    Destroy(this.gameObject);
                })
                .AddTo(this);
        }

        public void ApplyDamage(AttackData attackData)
        {
            _currentParameter.Hp -= attackData.Power;

            if (_currentParameter.Hp <= 0)
            {
                _lastAttackData = attackData;
            }
        }
        
        
    }
}
