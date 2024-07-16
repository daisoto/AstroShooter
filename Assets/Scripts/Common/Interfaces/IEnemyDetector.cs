using System;
using UnityEngine;

namespace Common.Interfaces
{
    public interface IEnemyDetector
    {
        IObservable<Vector2> EnemyPosition { get; }
    }
}