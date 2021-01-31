using UnityEngine;

namespace Gather.Scripts
{
    
    [CreateAssetMenu(menuName = "Gather/FieldObjectDataStorage", fileName = "FieldObjectDataStorage")]
    public class FieldObjectDataStorage : ScriptableObject
    {
        [SerializeField]
        private FieldObjectMetaDataObject[] _fieldObjectMetaDataObjects;

        public GameObject FindRandom()
        {
            var index = Random.Range(0, _fieldObjectMetaDataObjects.Length);
            return _fieldObjectMetaDataObjects[index].gameObject;
        }
    }
}
