using UnityEngine;

namespace Player
{
    public interface IPlayerPositionProvider
    {
        Vector2 Position { get; }
    }
}