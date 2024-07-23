using UnityEngine;

namespace Common
{
    public interface ISpawnPointsProvider
    {
        Transform[] Points { get; }
    }
}