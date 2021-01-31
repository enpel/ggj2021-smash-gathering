using Gather.Scripts.FieldObjectComponent;
using UnityEngine;

namespace Gather.Scripts.Factory
{
    public class FieldObjectFactory
    {
        private readonly FieldObjectStateNotificator _fieldObjectStateNotificator;
        private readonly FieldObjectDataStorage _fieldObjectDataStorage;

        public FieldObjectFactory(FieldObjectStateNotificator fieldObjectStateNotificator
        , FieldObjectDataStorage fieldObjectDataStorage)
        {
            _fieldObjectStateNotificator = fieldObjectStateNotificator;
            _fieldObjectDataStorage = fieldObjectDataStorage;
        }

        public GameObject CreateRandom()
        {
            var prefab = _fieldObjectDataStorage.FindRandom();
            var clone =  GameObject.Instantiate(prefab);

            var destructibleObject = clone.GetComponent<IDestructibleObject>();
            destructibleObject?.Setup(_fieldObjectStateNotificator);

            return clone;
        }
    }
}
