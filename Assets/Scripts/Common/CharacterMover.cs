using Common.Interfaces;
using UnityEngine;

public class CharacterMover: ICharacterMover
{
    private readonly Rigidbody2D _rigidbody;
    private readonly ISpeedProvider _speedProvider;

    public CharacterMover(Rigidbody2D rigidbody, ISpeedProvider speedProvider)
    {
        _rigidbody = rigidbody;
        _speedProvider = speedProvider;
    }

    public void MoveDirection(Vector2 direction)
    {
        var position = _rigidbody.position + direction * Time.deltaTime * _speedProvider.GetSpeed();
        _rigidbody.MovePosition(position);
    }
}