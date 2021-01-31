using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Gather.Scripts.Domain.Data;
using Gather.Scripts.ProjectRoot;
using Gather.Scripts.Unity.Factory;
using Gather.Scripts.Unity.Stage;
using Ludiq.OdinSerializer.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Gather.Scripts.Unity
{
    public class RoundDirector : IInitializable
    {
        private readonly IPlayerProvider _playerProvider;
        private readonly StageScoreManager _stageScoreManager;
        private readonly IPlayerFactory _playerFactory;
        private readonly StageMapSetting _stageMapSetting;
        private readonly IBasketFactory _basketFactory;
        private readonly ScoreManager _scoreManager;
        private GamePlaySettingData _currentGamePlaySetting;
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        public RoundDirector(IPlayerProvider playerProvider, StageScoreManager stageScoreManager, IPlayerFactory playerFactory, StageMapSetting stageMapSetting, IBasketFactory basketFactory,
            ScoreManager scoreManager)
        {
            _playerProvider = playerProvider;
            _stageScoreManager = stageScoreManager;
            _playerFactory = playerFactory;
            _stageMapSetting = stageMapSetting;
            _basketFactory = basketFactory;
            _scoreManager = scoreManager;
        }

        public void Setup(GamePlaySettingData gamePlaySettingData)
        {
            _currentGamePlaySetting = gamePlaySettingData;
        }

        public void RoundStart()
        {
            RoundStartTask(_currentGamePlaySetting).Forget();
        }

        public void Reset()
        {
            _cancellationTokenSource.Cancel();
        }

        private async UniTaskVoid RoundStartTask(GamePlaySettingData gamePlaySettingData)
        {
            Debug.Log("なんかいっぱい準備する");
            // なんかスタートする
            var players = _playerProvider.GetCurrentPlayers();
            var spawnPoints = new Queue<Transform>();
            _stageMapSetting.GetPlayerSpawnPoints().ForEach(x => spawnPoints.Enqueue(x));

            players.ForEach(x => _stageScoreManager.AddPlayer(x));
            players.ForEach(x =>
            {
                var player = _playerFactory.Create(x);
                var spawnPoint = spawnPoints.Dequeue();
                player.transform.position = spawnPoint.position;
                player.transform.rotation = spawnPoint.rotation;
                var basket = _basketFactory.Create();
                player.SetBasket(basket);
                basket.transform.localPosition = Vector3.zero;
                
            });

            // debug用
            var gameObject = new GameObject();
            var scoreView = gameObject.AddComponent<DebugPlayerScoreView>();
            scoreView.Setup(_scoreManager);

            var correctedCount = 0;
            while (correctedCount < _currentGamePlaySetting.CorrectCount)
            {
                correctedCount++;
                
                // 次の便まで待つ
                await UniTask.Delay(TimeSpan.FromSeconds(_currentGamePlaySetting.CorrectInterval));
                
                // 便がくる
                
                // 回収装置が満タンになるまで待つ
                
                // 回収装置が退場する
                
                // ポイントが精算される。
                
            }
            

            if (_cancellationTokenSource.IsCancellationRequested)
            {
                return;
            }
            
            // 終了～～～～～

            SceneManager.LoadScene("ResultScene");
        }

        public void Initialize()
        {
            _cancellationTokenSource =  new CancellationTokenSource();
        }
    }
}
