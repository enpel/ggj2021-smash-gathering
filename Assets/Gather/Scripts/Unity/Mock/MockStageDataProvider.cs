using Gather.Scripts.Unity.Interface;
using Gather.Scripts.Unity.ScriptableObject;
using UnityEngine;

public class MockStageDataProvider:MonoBehaviour, IStageDataProvider
{
    [SerializeField] private StageDataScriptableObject mockData;
    public StageDataScriptableObject GetStageData()
    {
        return mockData;
    }
}