using System;
using System.Linq;
using Common;
using UniRx;
using UnityEngine;
using Zenject;

namespace Field
{
    public class GameField : MonoBehaviour, ISpawnPointsProvider
    {
        public Vector2[] EnemyPoints => _enemyPointsInternal ??= _enemyPoints.Select(GetPosition).ToArray();
        private Vector2[] _enemyPointsInternal; 
        [SerializeField] 
        private Transform[] _enemyPoints;

        public Vector2 PlayerPoint => _playerPointInternal ??= GetPosition(_playerPoint);
        private Vector2? _playerPointInternal;
        [SerializeField] 
        private Transform _playerPoint;

        [InjectLocal]
        private readonly IHealthComponent _health;
        [InjectLocal]
        private readonly IDeathProcessor _deathProcessor;
        [InjectLocal] 
        private readonly ISetupable[] _setupables;

        private IDisposable _runDisposable;
        
        #region fluent builder

        public GameField SetOnDeath(OnDeath onDeath)
        {
            _deathProcessor.SetOnPreDeath(onDeath);

            return this;
        }

        public GameField SetHealth(int health)
        {
            _health.Reset(health);
            
            return this;
        }
        
        #endregion

        public void Run()
        {
            _runDisposable?.Dispose();
            var cd = new CompositeDisposable();
            Array.ForEach(_setupables, s => s.Setup().AddTo(cd)); 
            _runDisposable = cd;
        }

        private Vector2 GetPosition(Transform t)
        {
            return new Vector2(t.position.x, t.position.y);
        }
    }
}