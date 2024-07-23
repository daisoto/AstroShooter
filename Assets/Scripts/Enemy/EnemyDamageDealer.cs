using Common;
using Zenject;

namespace Enemy
{
    public class EnemyDamageDealer: DamageDealer
    {
        [InjectLocal]
        private readonly IHealthComponent _healthComponent;

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