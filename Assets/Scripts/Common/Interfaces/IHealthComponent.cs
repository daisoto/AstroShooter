using UniRx;

namespace Common
{
    public interface IHealthComponent
    {
        IReadOnlyReactiveProperty<int> Health { get; }

        void Reset(int health);

        void Decrease(int value);

        void Kill();
    }
}