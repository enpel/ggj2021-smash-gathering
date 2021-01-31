using Gather.Scripts.Domain.Data;
using Gather.Scripts.Factory;
using Gather.Scripts.ProjectRoot;
using Gather.Scripts.Unity;
using Gather.Scripts.Unity.Factory;
using Gather.Scripts.Unity.Interface;
using Gather.Scripts.Unity.ScriptableObject;
using Gather.Scripts.Unity.Stage;
using Gather.Scripts.Unity.Tmp;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Gather.Scripts
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private FieldObjectDataStorage _fieldObjectDataStorage;
        [SerializeField] private TestFieldObjectSpawner _testFieldObjectSpawner;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private StageMapSetting _stageMapSetting;
        [SerializeField] private StagePrefabHolder _prefabHolder;
        [SerializeField] private MockStageDataProvider _stageMockData;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameDirector>(Lifetime.Scoped);
            builder.RegisterInstance(_fieldObjectDataStorage);
            builder.Register<FieldObjectFactory>(Lifetime.Scoped);
            builder.Register<FieldObjectStateNotificator>(Lifetime.Scoped);

            builder.RegisterInstance(new GamePlaySettingData(3, 10));
            builder.Register<ScoreManager>(Lifetime.Scoped).AsImplementedInterfaces().AsSelf();

            builder.Register<RoundDirector>(Lifetime.Scoped);
            builder.Register<StageScoreManager>(Lifetime.Scoped);

            builder.RegisterInstance<StagePrefabHolder>(_prefabHolder);
            builder.Register<PlayerFromHolderFactory>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<BasketFromHolderFactory>(Lifetime.Scoped).AsImplementedInterfaces();
            
            builder.RegisterInstance<StageMapSetting>(_stageMapSetting);
            
            builder.RegisterComponent(_testFieldObjectSpawner);
            builder.RegisterInstance(_stageMockData).As<IStageDataProvider>();

        }
    }
}
