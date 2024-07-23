using Common;
using UnityEngine;

namespace Projectile
{
    public interface IProjectileMoveProvider: IMoveProvider
    {
        void SetDirection(Vector2 direction);
    }
}