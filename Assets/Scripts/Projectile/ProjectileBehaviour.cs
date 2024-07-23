using System;
using Common;
using UniRx;
using UnityEngine;
using Zenject;

namespace Projectile
{
    public class ProjectileBehaviour: MonoBehaviour, 
        IPoolable<IMemoryPool<ProjectileBehaviour>>, IDespawnable
    {
        private IDamageDealer _damageDealer;
        private IProjectileMoveProvider _moveProvider;
        private IPositionSetter _positionSetter;
        private ISetupable[] _setupables;
        
        private IMemoryPool<ProjectileBehaviour> _pool;
        private IDisposable _runDisposable;

        [Inject]
        public void Construct(IDamageDealer damageDealer, IPositionSetter positionSetter, 
            IProjectileMoveProvider moveProvider, ISetupable[] setupables)
        {
            _damageDealer = damageDealer;
            _positionSetter = positionSetter;
            _moveProvider = moveProvider;
            _setupables = setupables;
        }
        
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

        public ProjectileBehaviour SetDirection(Vector2 direction)
        {
            _moveProvider.SetDirection(direction);
            transform.rotation = Quaternion.LookRotation(direction, Vector3.forward);
            
            return this;
        }
        
        #endregion

        public void Run()
        {
            var cd = new CompositeDisposable();
            Array.ForEach(_setupables, s => s.Setup().AddTo(cd)); 
            _runDisposable = cd;
        }

        public void OnDespawned()
        {
            gameObject.SetActive(false);
            _runDisposable?.Dispose();
        }

        public void OnSpawned(IMemoryPool<ProjectileBehaviour> pool)
        {
            gameObject.SetActive(true);
            _pool = pool;
        }

        public void Despawn()
        {
            _pool.Despawn(this);
        }

        public class Pool : MemoryPool<ProjectileBehaviour>
        {
            protected override void OnCreated(ProjectileBehaviour item)
            {
                item.gameObject.SetActive(false);
            }
            
            // protected override void OnSpawned(ProjectileBehaviour item)
            // {
            //     item.OnSpawned(this);
            // }
            //
            // protected override void OnDespawned(ProjectileBehaviour item)
            // {
            //     item.OnDespawned();
            // }
        }
    }
}