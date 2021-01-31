using Gather.Scripts.Domain.Data;

namespace Gather.Scripts.FieldObjectComponent
{
    public interface IDestructibleObject
    {
        void ApplyDamage(AttackData attackData);
        void Setup(FieldObjectStateNotificator fieldObjectStateNotificator);
    }
}
