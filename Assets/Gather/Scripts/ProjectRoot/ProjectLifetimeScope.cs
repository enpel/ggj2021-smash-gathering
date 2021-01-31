using VContainer;
using VContainer.Unity;

namespace Gather.Scripts.ProjectRoot
{
    public class ProjectLifetimeScope : VContainer.Unity.LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameInitializer>(Lifetime.Singleton);
            builder.Register<PlayerManager>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }

}
