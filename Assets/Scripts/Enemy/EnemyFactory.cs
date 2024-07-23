using Common;
using Settings;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public class EnemyFactory: IFactory<Vector2, OnDeath, EnemyBehaviour>
    {
        private readonly EnemySettings _settings;
        private readonly IMemoryPool<EnemyBehaviour> _pool;

        public EnemyFactory(EnemySettings settings, IMemoryPool<EnemyBehaviour> pool)
        {
            _settings = settings;
            _pool = pool;
        }

        public EnemyBehaviour Create(Vector2 position, OnDeath onDeath)
        {
            return _pool
                .Spawn()
                .SetPosition(position)
                .SetOnDeath(onDeath)
                .SetHealth(_settings.EnemyHealth)
                .SetDamageDealt(_settings.EnemyDamage)
                .SetSpeed(Random.Range(_settings.MinEnemySpeed, _settings.MaxEnemySpeed));
        }
    }
}