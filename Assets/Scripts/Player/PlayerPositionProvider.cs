using UnityEngine;

namespace Player
{
    public class PlayerPositionProvider: IPlayerPositionProvider
    {
        private readonly Transform _transform;

        public Vector2 Position => _transform.position;

        public PlayerPositionProvider(Transform transform)
        {
            _transform = transform;
        }
    }
}