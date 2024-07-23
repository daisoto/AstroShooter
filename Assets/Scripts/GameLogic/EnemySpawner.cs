using System;
using System.Collections.Generic;
using Common;
using Enemy;
using GameLogic.Interfaces;
using UniRx;
using UnityEngine;
using Zenject;

namespace GameLogic
{
    public class EnemySpawner: IEnemySpawner
    {
        private readonly IEnemySpawnPointProvider _pointProvider;
        private readonly IFactory<Vector2, Action<EnemyBehaviour>, EnemyBehaviour> _factory;
        private readonly IEnemyTimer _timer;
        private readonly IEventBus _bus;

        private List<EnemyBehaviour> _enemies = new();
        private int _count;
        private int _enemiesNum;

        public EnemySpawner(IEnemySpawnPointProvider pointProvider, 
            IFactory<Vector2, Action<EnemyBehaviour>, EnemyBehaviour> factory, IEnemyTimer timer, IEventBus bus)
        {
            _pointProvider = pointProvider;
            _factory = factory;
            _timer = timer;
            _bus = bus;
        }

        public IDisposable StartSpawn(int enemiesNum)
        {
            var cd = new CompositeDisposable();
            _enemiesNum = enemiesNum;
            _count = 0;

            _timer
                .Setup()
                .AddTo(cd);
            
            _timer
                .Ring
                .Subscribe(_ => Spawn())
                .AddTo(cd);

            Disposable
                .Create(DestroyEnemies)
                .AddTo(cd);

            return cd;
        }

        private void Spawn()
        {
            if (_count < _enemiesNum)
            {
                var enemy = _factory.Create(_pointProvider.GetPoint(), OnDeath);
                enemy.Run();
                _enemies.Add(enemy);
                _count++;
            }
        }

        private void OnDeath(EnemyBehaviour enemy)
        {
            _enemies.Remove(enemy);
            _bus.Dispatch(new EnemyKilledEvent());
        }

        private void DestroyEnemies()
        {
            _enemies.ForEach(e => e.Despawn());
            _enemies.Clear();
        }
    }
}