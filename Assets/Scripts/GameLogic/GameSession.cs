using System;
using GameLogic.Interfaces;
using UniRx;
using Zenject;

namespace GameLogic
{
    public class GameSession: IGameSession, IPoolable<IMemoryPool<IGameSession>>
    {
        public bool IsActive { get; private set; }

        private readonly IEnemySpawner _enemySpawner;
        private readonly IEventBus _bus;

        private IMemoryPool<IGameSession> _pool;
        private int _enemiesNum;
        private int _killedEnemies;
        private IDisposable _dis;

        public GameSession(IEnemySpawner enemySpawner, IEventBus bus)
        {
            _enemySpawner = enemySpawner;
            _bus = bus;
        }

        public void SetEnemiesNum(int num)
        {
            _enemiesNum = num;
        }
        
        public void Start()
        {
            var cd = new CompositeDisposable();
            _killedEnemies = 0;
            
            _enemySpawner
                .StartSpawn(_enemiesNum)
                .AddTo(cd);

            _bus
                .Subscribe<EnemyKilledEvent>(_ => OnEnemyKilled())
                .AddTo(cd);

            _bus
                .Subscribe<PlayerKilledEvent>(_ => OnPlayerKilled())
                .AddTo(cd);

            _dis = cd;
            IsActive = true;
        }
        
        public void Stop()
        {
            _dis?.Dispose();
            IsActive = false;
            _pool.Despawn(this);
        }

        public void OnSpawned(IMemoryPool<IGameSession> pool)
        {
            _pool = pool;
        }

        public void OnDespawned()
        {
            _enemiesNum = 0;
        }
        
        private void OnEnemyKilled()
        {
            _killedEnemies++;
            if (_killedEnemies >= _enemiesNum)
            {
                _bus.Dispatch(new WinGameEvent());
            }
        }

        private void OnPlayerKilled()
        {
            _bus.Dispatch(new LoseGameEvent());
        }

        public class Pool : MemoryPool<IGameSession> { }
    }
}