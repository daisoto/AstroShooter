using UnityEngine;

namespace GameLogic
{
    public interface IEnemySpawnPointProvider
    {
        Vector3 GetPoint();
    }
}