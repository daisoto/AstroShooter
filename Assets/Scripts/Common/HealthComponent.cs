using UniRx;

namespace Common
{
    public class HealthComponent: IHealthComponent
    {
        public IReadOnlyReactiveProperty<int> Health => _health;
        private readonly ReactiveProperty<int> _health = new();

        public void Reset(int health)
        {
            _health.Value = health;
        }

        public void Decrease(int value)
        {
            _health.Value -= value;
        }

        public void Kill()
        {
            _health.Value = 0;
        }
    }
}