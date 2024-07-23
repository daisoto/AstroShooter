using System;
using Common;
using UniRx;
using UnityEngine;

namespace Player
{
    public class PlayerShootController : ISetupable
    {
        private readonly IEnemyDetector _enemyDetector;
        private readonly IShootingRateTimer _shootingRateTimer;
        private readonly IShooter _shooter;

        public PlayerShootController(IEnemyDetector enemyDetector, 
            IShootingRateTimer shootingRateTimer, IShooter shooter)
        {
            _enemyDetector = enemyDetector;
            _shootingRateTimer = shootingRateTimer;
            _shooter = shooter;
        }

        public IDisposable Setup()
        {
            return _enemyDetector
                .EnemyPosition
                .Subscribe(Shoot);
        }

        private void Shoot(Vector2 target)
        {
            if (_shootingRateTimer.CanShoot)
            {
                _shooter.Shoot(target);
                _shootingRateTimer.Reset();
            }
        }
    }
}