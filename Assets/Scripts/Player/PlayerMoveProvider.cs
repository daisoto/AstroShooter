using System;
using Common;
using UnityEngine;
using UniRx;

namespace Player
{
    public class PlayerMoveProvider: IMoveProvider
    {
        public IObservable<Vector2> MoveVector => _move;
        private readonly ReactiveCommand<Vector2> _move = new();

        private readonly InputManager _inputManager;

        private float _speed;

        public PlayerMoveProvider(InputManager inputManager)
        {
            _inputManager = inputManager;
        }

        public IDisposable Setup()
        {
            return Observable
                .EveryFixedUpdate()
                .Subscribe(_ => 
                    _move.Execute(_inputManager.MoveDirection * _speed * Time.deltaTime));
        }
        
        public void SetSpeed(float speed)
        {
            _speed = speed;
        }
    }
}