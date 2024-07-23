using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "New FieldSettings", menuName = "Settings/FieldSettings")]
    public class FieldSettings: ScriptableObject
    {        
        [field: SerializeField] 
        public int Health { get; private set; }
    }
}