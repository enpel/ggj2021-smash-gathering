using UnityEngine;

namespace Gather.Scripts.FieldObjectComponent
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class PickableObject : MonoBehaviour, IPickableObject
    {
        private bool _isPicked = false;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = this.GetComponent<Rigidbody>();
        }

        public Transform TryPickup()
        {
            if (_isPicked) return null;

            _isPicked = true;
            _rigidbody.isKinematic = true;
            this.gameObject.layer = LayerMask.NameToLayer("Picked");
            
            return this.transform;
        }

        public void Release()
        {
            _isPicked = false;
            _rigidbody.isKinematic = false;
            this.gameObject.layer = LayerMask.NameToLayer("FieldObject");
        }

        public void Release(Vector3 forceVelocity)
        {
            Release();
            _rigidbody.AddForce(forceVelocity, ForceMode.Impulse);
        }

        public void SetParent(Transform parent)
        {
            this.transform.SetParent(parent);
        }
    }
}
