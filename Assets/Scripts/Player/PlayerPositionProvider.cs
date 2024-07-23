using UnityEngine;

namespace Player
{
    public class PlayerPositionProvider: IPlayerPositionProvider
    {
        private readonly Rigidbody2D _rigidbody;

        public Vector2 Position => _rigidbody.position;

        public PlayerPositionProvider(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }
    }
}