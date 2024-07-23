using System;
using Common;
using UniRx;

namespace GameLogic.Interfaces
{
    public interface IEnemyTimer: ISetupable
    {
        IObservable<Unit> Ring { get; }
    }
}