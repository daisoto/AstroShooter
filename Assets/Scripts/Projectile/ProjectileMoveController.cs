using System;
using Common.Interfaces;
using UniRx;
using Zenject;

namespace Projectile
{
    public class ProjectileMoveController: IInitializable, IDisposable
    {
        private readonly ICharacterMover _characterMover;
        private readonly IMoveProvider _moveProvider;

        private IDisposable _sub;

        public ProjectileMoveController(ICharacterMover characterMover)
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