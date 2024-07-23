using System;
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
        private readonly IFactory<Vector2, OnDeath, EnemyBehaviour> _factory;
        private readonly IEnemyTimer _timer;
        private readonly IEventBus _bus;

        public EnemySpawner(IEnemySpawnPointProvider pointProvider, 
            IFactory<Vector2, OnDeath, EnemyBehaviour> factory, IEnemyTimer timer, IEventBus bus)
        {
            _pointProvider = pointProvider;
            _factory = factory;
            _timer = timer;
            _bus = bus;
        }

        public IDisposable StartSpawn(int enemiesNum)
        {
            var cd = new CompositeDisposable();
            
            var count = 0;

            _timer
                .Setup()
                .AddTo(cd);
            
            _timer
                .Ring
                .Subscribe(_ => Spawn())
                .AddTo(cd);

            return cd;

            void Spawn()
            {
                if (count < enemiesNum)
                {
                    _factory
                        .Create(_pointProvider.GetPoint(), OnDeath)
                        .Run();
                    count++;
                }
            }

            void OnDeath()
            {
                _bus.Dispatch(new EnemyKilledEvent());
            }
        }
    }
}