using System;
using Common.Interfaces;
using Zenject;
using UniRx;

namespace Enemy
{
    public class EnemyMoveController: IInitializable, IDisposable
    {
        private readonly ICharacterMover _characterMover;
        private readonly IMoveProvider _moveProvider;

        private IDisposable _sub;

        public EnemyMoveController(ICharacterMover characterMover)
        {
            _characterMover = characterMover;
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