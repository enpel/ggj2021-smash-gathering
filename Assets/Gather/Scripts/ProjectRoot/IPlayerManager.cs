using System;
using Gather.Scripts.Domain.Data;

namespace Gather.Scripts.ProjectRoot
{
    public interface IPlayerManager
    {
        void AddPlayer();
        void RemoveLastPlayer();
        IObservable<PlayerData> AddPlayerAsObservable();
        IObservable<PlayerData> RemovePlayerAsObservable();
    }
}