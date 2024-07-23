using System;
using UnityEngine;

namespace Common
{
    public interface IMoveProvider: ISetupable
    {
        IObservable<Vector2> MoveVector { get; }
        void SetSpeed(float speed);
    }
}