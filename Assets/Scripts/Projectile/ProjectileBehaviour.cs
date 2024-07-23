using System;
using Common;
using UniRx;
using UnityEngine;
using Zenject;

namespace Projectile
{
    public class ProjectileBehaviour: MonoBehaviour, 
        IPoolable<IMemoryPool<ProjectileBehaviour>>
    {
        [InjectLocal]
        private readonly IProjectileDamageDealer _damageDealer;
        [InjectLocal]
        private readonly IProjectileMoveProvider _moveProvider;
        [InjectLocal]
        private readonly IPositionSetter _positionSetter;
        [InjectLocal]
        private readonly ISetupable[] _setupables;
        
        private IMemoryPool<ProjectileBehaviour> _pool;
        private IDisposable _runDisposable;
        
        #region fluent builder

        public ProjectileBehaviour SetPosition(Vector2 position)
        {
            _positionSetter.SetPosition(position);
            
            return this;
        }

        public ProjectileBehaviour SetSpeed(float speed)
        {
            _moveProvider.SetSpeed(speed);
            
            return this;
        }

        public ProjectileBehaviour SetDamage(int damage)
        {
            _damageDealer.SetDamageDealt(damage);
            
            return this;
        }

        public ProjectileBehaviour SetDespawnAfterDamage()
        {
            _damageDealer.SetOnDamage(() => _pool.Despawn(this));
            
            return this;
        }

        public ProjectileBehaviour SetDirection(Vector2 direction)
        {
            _moveProvider.SetDirection(direction);
            transform.rotation = Quaternion.FromToRotation(Vector3.right, direction);
            
            return this;
        }
        
        #endregion

        public void Run()
        {
            var cd = new CompositeDisposable();
            Array.ForEach(_setupables, s => s.Setup().AddTo(cd)); 
            _runDisposable = cd;
            gameObject.SetActive(true);
        }

        public void OnDespawned()
        {
            gameObject.SetActive(false);
            _runDisposable?.Dispose();
        }

        public void OnSpawned(IMemoryPool<ProjectileBehaviour> pool)
        {
            _pool = pool;
        }

        public class Pool : MemoryPool<ProjectileBehaviour>
        {
            protected override void OnCreated(ProjectileBehaviour item)
            {
                item.gameObject.SetActive(false);
            }
            
            protected override void OnSpawned(ProjectileBehaviour item)
            {
                item.OnSpawned(this);
            }
            
            protected override void OnDespawned(ProjectileBehaviour item)
            {
                item.OnDespawned();
            }
        }
    }
}