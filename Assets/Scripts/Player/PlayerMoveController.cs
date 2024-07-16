using System;
using Common.Interfaces;
using UniRx;
using Zenject;

namespace Player
{
    public class PlayerMoveController : IInitializable, IDisposable
    {
        private readonly IMoveProvider _moveProvider;
        private readonly ICharacterMover _characterMover;

        private IDisposable _sub;

        public PlayerMoveController(IMoveProvider moveProvider)
        {
            _moveProvider = moveProvider;
        }

        public void Initialize()
        {
            _sub = _moveProvider
                .Move
                .Subscribe(_characterMover.MoveDirection);
        }

        public void Dispose() => _sub?.Dispose();
    }
}