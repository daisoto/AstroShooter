using UnityEngine;

namespace Common
{
    public class Mover : IMover
    {
        private readonly Rigidbody2D _rigidbody;

        public Mover(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void Move(Vector2 vector)
        {
            var position = _rigidbody.position + vector;
            _rigidbody.MovePosition(position);
        }
    }
}