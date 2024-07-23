using System;

namespace GameLogic
{
    public interface IEnemySpawner
    {
        IDisposable StartSpawn(int enemiesNum);
    }
}