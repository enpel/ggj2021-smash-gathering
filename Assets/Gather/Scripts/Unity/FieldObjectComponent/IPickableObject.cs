using UnityEngine;

namespace Gather.Scripts.FieldObjectComponent
{
    public interface IPickableObject
    {
        Transform TryPickup();
        void Release();
        void Release(Vector3 forceVelocity);
        void SetParent(Transform transform);
    }
}
