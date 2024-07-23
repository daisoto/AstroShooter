using Common;
using UnityEngine;
using Zenject;

namespace Field
{
    public class GameField : MonoBehaviour, ISpawnPointsProvider
    {
        [field: SerializeField] 
        public Transform[] Points { get; private set; }

        private IHealthComponent _health;
        private IDeathProcessor _deathProcessor;

        [Inject]
        private void Construct(IHealthComponent health, IDeathProcessor deathProcessor)
        {
            _health = health;
            _deathProcessor = deathProcessor;
        }
        
        #region fluent builder

        public GameField SetOnDeath(OnDeath onDeath)
        {
            _deathProcessor.SetOnDeath(onDeath);

            return this;
        }

        public GameField SetHealth(int health)
        {
            _health.Reset(health);
            
            return this;
        }
        
        #endregion
    }
}