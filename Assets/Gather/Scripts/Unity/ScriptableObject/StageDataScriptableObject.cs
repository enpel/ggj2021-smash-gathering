using UnityEngine;

namespace Gather.Scripts.Unity.ScriptableObject
{
    [CreateAssetMenu(menuName = "Gather/StageDataScriptableObject", fileName = "StageDataScriptableObject")]
    public class StageDataScriptableObject : UnityEngine.ScriptableObject
    {
        public string SceneName;
    }
}
