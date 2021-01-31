using System;
using Gather.Scripts.Domain.Data;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Gather.Scripts.Unity
{
    public interface IPlayerAlreadyNotificator
    {
        IObservable<Tuple<PlayerData, bool>> IsAlreadyPlayerAsObservable();
    }
    
    public class GameStartPresenter:IStartable
    {
        private readonly IPlayerAlreadyNotificator _playerAlreadyNotificator;
        private CompositeDisposable _disposable = new CompositeDisposable();

        public GameStartPresenter(IPlayerAlreadyNotificator playerAlreadyNotificator)
        {
            _playerAlreadyNotificator = playerAlreadyNotificator;
        }
        
        public void Start()
        {
            _playerAlreadyNotificator.IsAlreadyPlayerAsObservable()
                    .Subscribe(x =>
                    {
                        Debug.Log("----");
                        SceneManager.LoadScene("GameScene");
                    })
                    .AddTo(_disposable);
        }
    }
}
