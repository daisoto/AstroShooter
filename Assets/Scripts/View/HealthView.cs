using UnityEngine;
using Zenject;

namespace View
{
    public class HealthView: MonoBehaviour, IPoolable<IMemoryPool<Transform, HealthView>>
    {
        public void OnSpawned(IMemoryPool<Transform, HealthView> pool)
        {
            gameObject.SetActive(true);
        }
        
        public void OnDespawned()
        { 
            gameObject.SetActive(false);
        }

        public class Pool : MemoryPool<Transform, HealthView>
        {
            protected override void Reinitialize(Transform parent, HealthView view)
            {
                view.transform.SetParent(parent);
            }
        }
    }
}