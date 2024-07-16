using System;
using UnityEngine;

namespace Common.Interfaces
{
    public interface IMoveProvider
    {
        public IObservable<Vector2> Move { get; }
    }
}