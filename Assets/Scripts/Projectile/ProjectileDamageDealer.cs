using Common;

namespace Projectile
{
    public class ProjectileDamageDealer: DamageDealer
    {
        private readonly IDespawnable _despawnable;

        public ProjectileDamageDealer(IDespawnable despawnable)
        {
            _despawnable = despawnable;
        }

        public override void TryDeal(IDamageReceiver receiver)
        {
            if (receiver.Type.HasFlag(DamageReceiverType.Enemy))
            {
                receiver.Receive(_damage);
                _despawnable.Despawn();
            }
        }
    }
}