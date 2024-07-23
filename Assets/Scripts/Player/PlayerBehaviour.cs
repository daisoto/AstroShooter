using System;
using Common;
using UniRx;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerBehaviour: MonoBehaviour
    {
        private IMoveProvider _moveProvider;
        private IEnemyDetector _enemyDetector;
        private IShootingRateTimer _shootingRateTimer;
        private ISetupable[] _setupables;
        
        private IDisposable _runDisposable;

        [Inject]
        public void Construct(IMoveProvider moveProvider, IEnemyDetector enemyDetector, 
            IShootingRateTimer shootingRateTimer, ISetupable[] setupables)
        {
            _moveProvider = moveProvider;
            _enemyDetector = enemyDetector;
            _shootingRateTimer = shootingRateTimer;
            _setupables = setupables;
        }
        
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
            _shootingRateTimer.SetRate(rate);
            
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