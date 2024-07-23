using Common;

namespace Projectile
{
    public class ProjectileDamageDealer: DamageDealer, IProjectileDamageDealer
    {
        private OnDamage _onDamage;

        public override void TryDeal(IDamageReceiver receiver)
        {
            if (receiver.Type.HasFlag(DamageReceiverType.Enemy))
            {
                receiver.Receive(_damage);
                _onDamage?.Invoke();
            }
        }

        public void SetOnDamage(OnDamage onDamage)
        {
            _onDamage = onDamage;
        }
    }
}