using UnityEngine;
using Zenject;

namespace Common
{
    [RequireComponent(typeof(Collider2D))]
    public class CollisionProcessor: MonoBehaviour
    {
        private IDamageReceiver _damageReceiver;

        [Inject]
        public void Construct(IDamageReceiver damageReceiver)
        {
            _damageReceiver = damageReceiver;
        }

        private void OnCollisionEnter2D(Collision2D other) 
            => Process(other.gameObject);

        private void OnTriggerEnter2D(Collider2D other)
            => Process(other.gameObject);

        private void Process(GameObject go)
        {
            if (go.TryGetComponent(out IDamageDealer dealer))
            {
                dealer.TryDeal(_damageReceiver);
            }
        }
    }
}