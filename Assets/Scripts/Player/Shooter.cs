using Projectile;
using UnityEngine;
using Zenject;

namespace Player
{
    public class Shooter: IShooter
    {
        private readonly IPlayerPositionProvider _positionProvider;
        private readonly IFactory<ProjectileData, ProjectileBehaviour> _projectilesFactory;

        private ProjectileData _data;

        public Shooter(IPlayerPositionProvider positionProvider, 
            IFactory<ProjectileData, ProjectileBehaviour> projectilesFactory)
        {
            _positionProvider = positionProvider;
            _projectilesFactory = projectilesFactory;
        }

        public void Shoot(Vector2 target)
        {
            var pos = _positionProvider.Position;
            _data.StartPosition = pos;
            _data.Direction = target - pos;
            
            _projectilesFactory.Create(_data).Run();
        }
    }
}