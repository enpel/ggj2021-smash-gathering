using UnityEngine;

namespace Gather.Scripts.Unity.Stage
{
    [CreateAssetMenu(menuName = "Gather/StagePrefabData", fileName = "StagePrefabData")]
    public class StagePrefabHolder : UnityEngine.ScriptableObject
    {
        public GameObject PlayerPrefab;
        public GameObject BasketPrefab;
    }
}
