using Common;

namespace Enemy
{
    public class EnemyDamageDealer: DamageDealer
    {
        private readonly IHealthComponent _healthComponent;

        public EnemyDamageDealer(IHealthComponent healthComponent)
        {
            _healthComponent = healthComponent;
        }

        public override void TryDeal(IDamageReceiver receiver)
        {
            if (!receiver.Type.HasFlag(DamageReceiverType.Enemy))
            {
                _healthComponent.Kill();
                receiver.Receive(_damage);
            }
        }
    }
}