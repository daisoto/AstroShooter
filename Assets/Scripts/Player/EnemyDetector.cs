using System;
using Enemy;
using UniRx;
using UnityEngine;

namespace Player
{
    public class EnemyDetector: IEnemyDetector
    {
        public IObservable<Vector2> EnemyPosition => _enemyPosition;
        private readonly ReactiveCommand<Vector2> _enemyPosition = new();

        private readonly IPlayerPositionProvider _positionProvider;

        private float _radius;

        public EnemyDetector(IPlayerPositionProvider positionProvider)
        {
            _positionProvider = positionProvider;
        }

        public IDisposable Setup()
        {
            return Observable
                .EveryUpdate()
                .Subscribe(_ =>
                {
                    var hits = Physics2D
                        .CircleCastAll(_positionProvider.Position, _radius, Vector2.zero);

                    foreach (var hit in hits)
                    {
                        if (hit.transform.gameObject.TryGetComponent(out EnemyBehaviour enemy) && 
                            enemy.IsAlive)
                        {
                            _enemyPosition.Execute(enemy.transform.position);
                            return;
                        }
                    }
                });
        }
        
        public void SetRadius(float radius)
        {
            _radius = radius;
        }
    }
}