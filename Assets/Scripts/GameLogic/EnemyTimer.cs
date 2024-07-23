using System;
using GameLogic.Interfaces;
using Settings;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameLogic
{
    public class EnemyTimer: IEnemyTimer
    {
        public IObservable<Unit> Ring => _ring;
        private readonly ReactiveCommand _ring;
        
        private readonly EnemySettings _settings;

        private float _time;
        private float _currentTimeOut;

        public EnemyTimer(EnemySettings settings)
        {
            _settings = settings;

            _ring = new();
        }

        public IDisposable Setup()
        {
            return Observable
                .EveryUpdate()
                .Subscribe(_ => Tick());
        }

        private void Tick()
        {
            _time += Time.deltaTime;

            if (_time >= _currentTimeOut)
            {
                _ring.Execute();
                _currentTimeOut = GetNewTimeOut();
                _time = 0;
            }
        }

        private float GetNewTimeOut() => 
            Random.Range(_settings.MinEnemiesSpawnTime, _settings.MaxEnemiesSpawnTime);
    }
}