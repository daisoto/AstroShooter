using Settings;
using UnityEngine;
using GameLogic.Interfaces;

namespace GameLogic
{
    public class EnemyNumberProvider: IEnemyNumberProvider
    {
        private readonly EnemySettings _settings;

        public EnemyNumberProvider(EnemySettings settings)
        {
            _settings = settings;
        }

        public int GetEnemyNumber() => Random.Range(_settings.MinEnemiesNumber, _settings.MaxEnemiesNumber + 1);
    }
}