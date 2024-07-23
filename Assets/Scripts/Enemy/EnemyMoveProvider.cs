using System;
using UniRx;
using UnityEngine;

namespace Enemy
{
    public class EnemyMoveProvider: IEnemyMoveProvider
    {
        public IObservable<Vector2> MoveVector => _move;
        private readonly ReactiveCommand<Vector2> _move = new();

        private float _speed;
        private bool _isInterrupted;

        public IDisposable Setup()
        {
            return Observable
                .EveryUpdate()
                .Subscribe(_ =>
                {
                    if (!_isInterrupted)
                    {
                        _move.Execute(Vector2.down * _speed);
                    }
                });
        }
        
        public void SetSpeed(float speed) => _speed = speed;

        public void SetInterrupted(bool flag) => _isInterrupted = flag;
    }
}