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
            return _inputManager
                .MoveDirection
                .Subscribe(dir => 
                    _move.Execute(dir * _speed));
        }
        
        public void SetSpeed(float speed)
        {
            _speed = speed;
        }
    }
}