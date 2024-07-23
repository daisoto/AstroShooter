using Common;
using Settings;

namespace Player
{
    public class PlayerRunner: IPlayerRunner
    {
        private readonly PlayerBehaviour _playerBehaviour;
        private readonly PlayerSettings _settings;
        private readonly ISpawnPointsProvider _spawnPointsProvider;

        public PlayerRunner(PlayerBehaviour playerBehaviour, PlayerSettings settings, 
            ISpawnPointsProvider spawnPointsProvider)
        {
            _playerBehaviour = playerBehaviour;
            _settings = settings;
            _spawnPointsProvider = spawnPointsProvider;
        }

        public void Run()
        {
            _playerBehaviour
                .SetSpeed(_settings.PlayerSpeed)
                .SetRadius(_settings.PlayerShootingRadius)
                .SetShootingRate(_settings.PlayerShootingRate)
                .SetPosition(_spawnPointsProvider.PlayerPoint)
                .Run();
        }

        public void Stop()
        {
            _playerBehaviour.Stop();
        }
    }
}