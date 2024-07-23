using UnityEngine;

namespace Common
{
    public abstract class DamageDealer: MonoBehaviour, IDamageDealerConfigurable
    {
        protected int _damage;

        public void SetDamageDealt(int damage)
        {
            _damage = damage;
        }

        public abstract void TryDeal(IDamageReceiver receiver);
    }
}