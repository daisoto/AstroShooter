using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace View
{
    public class HealthBarView: MonoBehaviour
    {
        [SerializeField] 
        private Transform _container;

        [Inject] 
        private IMemoryPool<Transform, HealthView> _pool;
        
        private readonly Stack<HealthView> _activeViews = new();

        public void SetHealth(int num)
        {
            var count = _activeViews.Count;
            var diff = num - count;
            if (diff > 0)
            {
                for (int i = 0; i < diff; i++)
                {
                    _activeViews.Push(_pool.Spawn(_container));
                }
            }
            else if (diff < 0)
            {
                for (int i = 0; i < -diff; i++)
                {
                    _pool.Despawn(_activeViews.Pop());
                }
            }
        }
        
        public void OnDestroy()
        {
            while (_activeViews.Count > 0)
            {
                _pool.Despawn(_activeViews.Pop());
            }
        }
    }
}