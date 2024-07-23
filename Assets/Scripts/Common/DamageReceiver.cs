using UnityEngine;
using Zenject;

namespace Common
{
    public class DamageReceiver: MonoBehaviour
    {
        [Inject]
        private readonly IHealthComponent _health;
        
        public void Receive(int damage)
        {
            _health.Decrease(damage);
        }
    }
}