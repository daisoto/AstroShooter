using System;
using Common;
using UniRx;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerBehaviour: MonoBehaviour
    {
        [InjectLocal]
        private readonly IMoveProvider _moveProvider;
        [InjectLocal]
        private readonly  IEnemyDetector _enemyDetector;
        [InjectLocal]
        private readonly  IShootingRateTimer _shootingRateTimer;
        [InjectLocal]
        private readonly  IPositionSetter _positionSetter;
        [InjectLocal]
        private readonly  ISetupable[] _setupables;
        
        private IDisposable _runDisposable;
        
        #region fluent builder

        public PlayerBehaviour SetSpeed(float speed)
        {
            _moveProvider.SetSpeed(speed);
            
            return this;
        }

        public PlayerBehaviour SetRadius(float radius)
        {
            _enemyDetector.SetRadius(radius);
            
            return this;
        }

        public PlayerBehaviour SetShootingRate(float rate)
        {
            _shootingRateTimer.SetTimeout(1f / rate);
            
            return this;
        }

        public PlayerBehaviour SetPosition(Vector3 position)
        {
            _positionSetter.SetPosition(position);
            
            return this;
        }
        
        #endregion

        public void Run()
        {
            var cd = new CompositeDisposable();
            Array.ForEach(_setupables, s => s.Setup().AddTo(cd)); 
            _runDisposable = cd;
        }

        public void Stop() => _runDisposable.Dispose();
    }
}