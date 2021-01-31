using Gather.Scripts.Factory;

namespace Gather.Scripts.Unity
{
    public class DestructibleObjectSpawner
    {
        private readonly FieldObjectFactory _factory;

        public DestructibleObjectSpawner(FieldObjectFactory factory)
        {
            _factory = factory;
        }
    }
}
