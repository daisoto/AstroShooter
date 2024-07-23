using UnityEngine;

namespace Common
{
    public class PositionSetter: IPositionSetter
    {
        private readonly Rigidbody2D _rigidbody;

        public PositionSetter(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void SetPosition(Vector2 position)
        {
            _rigidbody.position = position;
        }
    }
}