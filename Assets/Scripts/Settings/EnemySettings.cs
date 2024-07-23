using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "New EnemySettings", menuName = "Settings/EnemySettings")]
    public class EnemySettings: ScriptableObject
    {
        [field: SerializeField] 
        public int MinEnemiesNumber { get; private set; }
        
        [field: SerializeField] 
        public int MaxEnemiesNumber { get; private set; }
        
        [field: Space, SerializeField] 
        public float MinEnemiesSpawnTime { get; private set; }
        
        [field: SerializeField] 
        public float MaxEnemiesSpawnTime { get; private set; }
        
        [field: Space, SerializeField] 
        public float MinEnemySpeed { get; private set; }
        
        [field: SerializeField] 
        public float MaxEnemySpeed { get; private set; }
        
        [field: Space, SerializeField] 
        public int EnemyHealth { get; private set; }
        
        [field: Space, SerializeField] 
        public int EnemyDamage { get; private set; }
    }
}