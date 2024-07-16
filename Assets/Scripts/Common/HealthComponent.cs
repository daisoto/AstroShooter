using UniRx;

namespace Components
{
    public class HealthComponent
    {
        public IReadOnlyReactiveProperty<int> Health => _health;
        private readonly ReactiveProperty<int> _health;

        public HealthComponent(int health)
        {
            _health = new(health);
        }

        public void Reset(int health)
        {
            _health.Value = health;
        }

        public void Decrease(int value)
        {
            _health.Value -= value;
        }
    }
}