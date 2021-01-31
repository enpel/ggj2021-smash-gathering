using Gather.Scripts.Unity.ScriptableObject;

namespace Gather.Scripts.Unity.Interface
{
    public interface IStageDataProvider
    {
        StageDataScriptableObject GetStageData();
    }
}