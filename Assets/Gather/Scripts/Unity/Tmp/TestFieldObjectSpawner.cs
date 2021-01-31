using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Gather.Scripts.Factory;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Random = System.Random;

namespace Gather.Scripts.Unity.Tmp
{
    public class TestFieldObjectSpawner:MonoBehaviour, IStartable
    {
        private FieldObjectFactory _factory;
        private CancellationTokenSource cancellationTokenSource;


        [Inject]
        public void Construct(FieldObjectFactory factory)
        {
            _factory = factory;
        }


        public void Start()
        {
            // CancellationTokenSourceを生成
            cancellationTokenSource = new CancellationTokenSource();
            LoopSpawnTask().Forget();
        }

        async UniTaskVoid LoopSpawnTask()
        {
            while (true)
            {
                for (int i = 0; i < 5; i++)
                {
                    SpawnBlock();
                }

                await UniTask.Delay(TimeSpan.FromSeconds(1));

                if (cancellationTokenSource.IsCancellationRequested)
                {
                    return;
                }
            }
        }

        private void SpawnBlock()
        {
            var clone =  _factory.CreateRandom();
            var spawnPoint = new Vector3(UnityEngine.Random.Range(-10, 10), 0 , UnityEngine.Random.Range(-10, 10));

            clone.transform.position = this.transform.position + spawnPoint;
        }

        void OnDestroy()
        {
            cancellationTokenSource?.Cancel();
        }
    }
}
