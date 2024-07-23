using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "New PlayerSettings", menuName = "Settings/PlayerSettings")]
    public class PlayerSettings: ScriptableObject
    {
        [field: SerializeField] 
        public float PlayerSpeed { get; private set; }
        
        [field: Space, SerializeField] 
        public float PlayerShootingRadius { get; private set; }
        
        [field: SerializeField] 
        public float PlayerShootingRate { get; private set; }
    }
}