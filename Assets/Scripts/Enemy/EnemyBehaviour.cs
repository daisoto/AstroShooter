using System;
using Common;
using UniRx;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public class EnemyBehaviour: MonoBehaviour, 
        IPoolable<IMemoryPool<EnemyBehaviour>>, IDespawnable
    {
        private IHealthComponent _health;
        private IEnemyMoveProvider _moveProvider;
        private IDeathProcessor _deathProcessor;
        private IPositionSetter _positionSetter;
        private IDamageDealer _damageDealer;
        private ISetupable[] _setupables;

        private IDisposable _runDisposable;
        private IMemoryPool<EnemyBehaviour> _pool;

        [Inject]
        public void Construct(IHealthComponent health, 
            IEnemyMoveProvider moveProvider, IDeathProcessor deathProcessor, 
            IPositionSetter positionSetter, IDamageDealer damageDealer, ISetupable[] setupables)
        {
            _health = health;
            _moveProvider = moveProvider;
            _deathProcessor = deathProcessor;
            _positionSetter = positionSetter;
            _damageDealer = damageDealer;
            _setupables = setupables;
        }

        #region fluent builder

        public EnemyBehaviour SetPosition(Vector2 position)
        {
            _positionSetter.SetPosition(position);
            
            return this;
        }

        public EnemyBehaviour SetOnDeath(OnDeath onDeath)
        {
            _deathProcessor.SetOnDeath(onDeath);

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
        }

        public void OnSpawned(IMemoryPool<EnemyBehaviour> pool)
        {
            gameObject.SetActive(true);
            _pool = pool;
        }

        public void OnDespawned()
        {
            gameObject.SetActive(false);
            _runDisposable?.Dispose();
        }

        public void Despawn()
        {
            _pool.Despawn(this);
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
            
            // protected override void OnSpawned(EnemyBehaviour item)
            // {
            //     item.OnSpawned(this);
            // }
            //
            // protected override void OnDespawned(EnemyBehaviour item)
            // {
            //     item.OnDespawned();
            // }
        }
    }
}