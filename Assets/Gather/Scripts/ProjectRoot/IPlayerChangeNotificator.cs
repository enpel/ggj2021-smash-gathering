using System;

namespace Gather.Scripts.ProjectRoot
{
    public interface IPlayerChangeNotificator
    {
        IObservable<int> ChangePlayerCountAsObservable();
    }
}