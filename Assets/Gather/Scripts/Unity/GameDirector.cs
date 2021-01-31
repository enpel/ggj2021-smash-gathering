using Gather.Scripts.Domain.Data;
using Gather.Scripts.Unity;
using Gather.Scripts.Unity.Interface;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Gather.Scripts
{
    public class GameDirector : IStartable, IInitializable
    {
        private readonly RoundDirector _roundDirector;
        private readonly IStageDataProvider _stageDataProvider;

        public GameDirector(RoundDirector roundDirector, IStageDataProvider stageDataProvider)
        {
            _roundDirector = roundDirector;
            _stageDataProvider = stageDataProvider;
        }

        public void Initialize()
        {
            Debug.Log("initialize");
        }
        void IStartable.Start()
        {
            SceneManager.LoadScene(_stageDataProvider.GetStageData().SceneName, LoadSceneMode.Additive);
            
            _roundDirector.Setup(new GamePlaySettingData(3, 10));
            _roundDirector.RoundStart();
        }

    }
}
