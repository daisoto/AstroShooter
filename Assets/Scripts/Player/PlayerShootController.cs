using System;
using Common.Interfaces;
using Settings;
using UniRx;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerShootController : IInitializable, IDisposable
    {
        private readonly PlayerSettings _settings;
        private readonly IEnemyDetector _enemyDetector;
        private readonly IShootPossibilityProvider _shootPossibilityProvider;
        private readonly IShooter _shooter;

        private IDisposable _sub;

        public PlayerShootController(PlayerSettings settings)
        {
            _settings = settings;
        }

        public void Initialize()
        {
            _sub = _enemyDetector
                .EnemyPosition
                .Subscribe(Shoot);
        }

        public void Dispose() => _sub?.Dispose();

        private void Shoot(Vector2 target)
        {
            if (_shootPossibilityProvider.CanShoot())
            {
                _shooter.Shoot(target);
            }
        }
    }
}