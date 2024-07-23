using Common;

namespace Projectile
{
    public interface IProjectileDamageDealer: IDamageDealerConfigurable
    {
        void SetOnDamage(OnDamage onDamage);
    }
}