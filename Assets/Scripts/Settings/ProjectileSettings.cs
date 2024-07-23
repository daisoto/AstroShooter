using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "New ProjectileSettings", menuName = "Settings/ProjectileSettings")]
    public class ProjectileSettings: ScriptableObject
    {
        [field: SerializeField] 
        public int ProjectileDamage { get; private set; }
        
        [field: SerializeField] 
        public float ProjectileSpeed { get; private set; }
    }
}