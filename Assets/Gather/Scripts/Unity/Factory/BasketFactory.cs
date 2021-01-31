using Gather.Scripts.Unity.Stage;
using UnityEngine;

namespace Gather.Scripts.Unity.Factory
{
    public interface IBasketFactory
    {
        Basket.Basket Create();
    }
    public class BasketFactory:IBasketFactory
    {
        private readonly GameObject _prefab;

        public BasketFactory(GameObject prefab)
        {
            _prefab = prefab;
        }

        public BasketFactory(StagePrefabHolder holder)
        {
            _prefab = holder.BasketPrefab;
        }

        public Basket.Basket Create()
        {
            return GameObject.Instantiate(_prefab).GetComponent<Basket.Basket>();
        }
    }
    
    public class BasketFromHolderFactory:IBasketFactory
    {
        private readonly GameObject _prefab;
        
        public BasketFromHolderFactory(StagePrefabHolder holder)
        {
            _prefab = holder.BasketPrefab;
        }

        public Basket.Basket Create()
        {
            return GameObject.Instantiate(_prefab).GetComponent<Basket.Basket>();
        }
    }
}