using Common;
using UnityEngine;

namespace GameLogic
{
    public class EnemySpawnPointProvider: IEnemySpawnPointProvider
    {
        private readonly ISpawnPointsProvider _spawnPoints;

        public EnemySpawnPointProvider(ISpawnPointsProvider spawnPoints)
        {
            _spawnPoints = spawnPoints;
        }

        public Vector3 GetPoint()
        {
            var points = _spawnPoints.Points;
            var index = Random.Range(0, points.Length);

            return points[index].position;
        }
    }
}