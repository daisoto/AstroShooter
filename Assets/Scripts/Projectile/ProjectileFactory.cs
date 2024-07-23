using Settings;
using Zenject;

namespace Projectile
{
    public class ProjectileFactory: IFactory<ProjectileData, ProjectileBehaviour>
    {
        private readonly ProjectileSettings _settings;
        private readonly IMemoryPool<ProjectileBehaviour> _pool;

        public ProjectileFactory(ProjectileSettings settings, IMemoryPool<ProjectileBehaviour> pool)
        {
            _settings = settings;
            _pool = pool;
        }

        public ProjectileBehaviour Create(ProjectileData data)
        {
            return _pool
                .Spawn()
                .SetPosition(data.StartPosition)
                .SetDirection(data.Direction)
                .SetSpeed(_settings.ProjectileSpeed)
                .SetDamage(_settings.ProjectileDamage);
        }
    }
}