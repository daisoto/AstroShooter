using UnityEngine;

public class GameField: MonoBehaviour
{
    [field: SerializeField] 
    public Transform[] SpawnPoints { get; private set; }
}