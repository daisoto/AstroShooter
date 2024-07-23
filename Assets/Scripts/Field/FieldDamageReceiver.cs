using Common;

namespace Field
{
    public class FieldDamageReceiver: IDamageReceiver
    {
        private readonly IHealthComponent _health;

        public FieldDamageReceiver(IHealthComponent health)
        {
            _health = health;
        }

        public void Receive(int damage)
        {
            _health.Decrease(damage);
        }

        public DamageReceiverType Type => DamageReceiverType.Wall;
    }
}