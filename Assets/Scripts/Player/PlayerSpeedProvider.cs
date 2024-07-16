using Common.Interfaces;
using Settings;

namespace Player
{
    public class PlayerSpeedProvider: ISpeedProvider
    {
        private readonly PlayerSettings _settings;

        public PlayerSpeedProvider(PlayerSettings settings)
        {
            _settings = settings;
        }

        public float GetSpeed() => _settings.PlayerSpeed;
    }
}