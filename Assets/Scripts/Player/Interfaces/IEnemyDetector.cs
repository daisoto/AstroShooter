using System;
using Common;
using UnityEngine;

namespace Player
{
    public interface IEnemyDetector: ISetupable
    {
        IObservable<Vector2> EnemyPosition { get; }

        void SetRadius(float radius);
    }
}