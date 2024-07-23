using UnityEngine;

namespace Common
{
    public class PositionSetter: IPositionSetter
    {
        private readonly Transform _transform;

        public PositionSetter(Transform transform)
        {
            _transform = transform;
        }

        public void SetPosition(Vector2 position)
        {
            _transform.position = position;
        }
    }
}