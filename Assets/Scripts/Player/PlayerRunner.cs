using Settings;

namespace Player
{
    public class PlayerRunner: IPlayerRunner
    {
        private readonly PlayerBehaviour _playerBehaviour;
        private readonly PlayerSettings _settings;

        public PlayerRunner(PlayerBehaviour playerBehaviour, PlayerSettings settings)
        {
            _playerBehaviour = playerBehaviour;
            _settings = settings;
        }

        public void Run()
        {
            _playerBehaviour
                .SetSpeed(_settings.PlayerSpeed)
                .SetRadius(_settings.PlayerShootingRadius)
                .SetShootingRate(_settings.PlayerShootingRate)
                .Run();
        }

        public void Stop()
        {
            _playerBehaviour.Stop();
        }
    }
}