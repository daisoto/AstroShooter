using System;
using UniRx;

namespace Common
{
    public class MoveController: IMoveController
    {
        private readonly IMover _mover;
        private readonly IMoveProvider _moveProvider;

        public MoveController(IMover mover, IMoveProvider moveProvider)
        {
            _mover = mover;
            _moveProvider = moveProvider;
        }

        public IDisposable Setup()
        {
            return _moveProvider
                .MoveVector
                .Subscribe(_mover.Move);
        }
    }
}