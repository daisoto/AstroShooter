using System;
using Common;
using UniRx;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public class EnemyBehaviour: MonoBehaviour, 
        IPoolable<IMemoryPool<EnemyBehaviour>>
    {
        [InjectLocal]
        private readonly IHealthComponent _health;
        [InjectLocal]
        private readonly IEnemyMoveProvider _moveProvider;
        [InjectLocal]
        private readonly IDeathProcessor _deathProcessor;
        [InjectLocal]
        private readonly IPositionSetter _positionSetter;
        [InjectLocal]
        private readonly IDamageDealerConfigurable _damageDealer;
        [InjectLocal]
        private readonly ISetupable[] _setupables;

        private IDisposable _runDisposable;
        private IMemoryPool<EnemyBehaviour> _pool;

        #region fluent builder

        public EnemyBehaviour SetPosition(Vector2 position)
        {
            _positionSetter.SetPosition(position);
            
            return this;
        }

        public EnemyBehaviour SetOnPreDeath(Action<EnemyBehaviour> onDeath)
        {
            OnDeath wrap = () => onDeath(this);
            _deathProcessor.SetOnPreDeath(wrap);

            return this;
        }

        public EnemyBehaviour SetOnAfterDeath()
        {
            _deathProcessor.SetOnAfterDeath(Despawn);

            return this;
        }

        public EnemyBehaviour SetSpeed(float speed)
        {
            _moveProvider.SetSpeed(speed);
            
            return this;
        }

        public EnemyBehaviour SetHealth(int health)
        {
            _health.Reset(health);
            
            return this;
        }

        public EnemyBehaviour SetDamageDealt(int damage)
        {
            _damageDealer.SetDamageDealt(damage);
            
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

        public void Despawn()
        {
            _pool.Despawn(this);
        }

        public void OnSpawned(IMemoryPool<EnemyBehaviour> pool)
        {
            _pool = pool;
        }

        public void OnDespawned()
        {
            gameObject.SetActive(false);
            _runDisposable?.Dispose();
        }

        public bool IsAlive => _health.Health.Value > 0;

        private void OnDestroy()
        {
            _runDisposable?.Dispose();
        }

        public class Pool : MemoryPool<EnemyBehaviour>
        {
            protected override void OnCreated(EnemyBehaviour item)
            {
                item.gameObject.SetActive(false);
            }
            
            protected override void OnSpawned(EnemyBehaviour item)
            {
                item.OnSpawned(this);
            }
            
            protected override void OnDespawned(EnemyBehaviour item)
            {
                item.OnDespawned();
            }
        }
    }
}