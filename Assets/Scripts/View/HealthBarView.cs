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
            if (num > count)
            {
                _activeViews.Push(_pool.Spawn(_container));
            }
            else if (num < count)
            {
                _pool.Despawn(_activeViews.Pop());
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