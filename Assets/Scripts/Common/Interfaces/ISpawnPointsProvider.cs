using UnityEngine;

namespace Common
{
    public interface ISpawnPointsProvider
    {
        Vector2[] EnemyPoints { get; }

        Vector2 PlayerPoint { get; }
    }
}