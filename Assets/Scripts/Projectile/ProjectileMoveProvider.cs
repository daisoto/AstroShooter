using System;
using UniRx;
using UnityEngine;

namespace Projectile
{
    public class ProjectileMoveProvider: IProjectileMoveProvider
    {
        public IObservable<Vector2> MoveVector => _move;
        private readonly ReactiveCommand<Vector2> _move = new();

        private float _speed;
        private Vector2 _direction;

        public IDisposable Setup()
        {
            return Observable
                .EveryUpdate()
                .Subscribe(_ =>
                {
                    _move.Execute(_direction * _speed);
                });
        }
        
        public void SetSpeed(float speed)
        {
            _speed = speed;
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }
    }
}