using System;
using Settings;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyFactory: IFactory<Vector2, Action<EnemyBehaviour>, EnemyBehaviour>
    {
        private readonly EnemySettings _settings;
        private readonly IMemoryPool<EnemyBehaviour> _pool;

        public EnemyFactory(EnemySettings settings, IMemoryPool<EnemyBehaviour> pool)
        {
            _settings = settings;
            _pool = pool;
        }

        public EnemyBehaviour Create(Vector2 position, Action<EnemyBehaviour> onDeath)
        {
            return _pool
                .Spawn()
                .SetPosition(position)
                .SetOnPreDeath(onDeath)
                .SetOnAfterDeath()
                .SetHealth(_settings.EnemyHealth)
                .SetDamageDealt(_settings.EnemyDamage)
                .SetSpeed(Random.Range(_settings.MinEnemySpeed, _settings.MaxEnemySpeed));
        }
    }
}