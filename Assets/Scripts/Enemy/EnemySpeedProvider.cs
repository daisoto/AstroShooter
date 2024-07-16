using Common.Interfaces;
using Settings;
using UnityEngine;

namespace Enemy
{
    public class EnemySpeedProvider: ISpeedProvider
    {
        private readonly EnemySettings _settings;

        public EnemySpeedProvider(EnemySettings settings)
        {
            _settings = settings;
        }

        public float GetSpeed() => 
            Random.Range(_settings.MinEnemiesSpeed, _settings.MaxEnemiesSpeed);
    }
}