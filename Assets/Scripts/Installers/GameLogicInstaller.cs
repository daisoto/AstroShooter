using System;
using System.Linq;
using Common;
using Enemy;
using Field;
using GameLogic;
using GameLogic.Interfaces;
using Player;
using Projectile;
using Settings;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameLogicInstaller: MonoInstaller<UIInstaller>
    {
        [SerializeField] 
        private GameField _gameField;

        [SerializeField] 
        private PlayerBehaviour _player;

        [Space, SerializeField] 
        private EnemyBehaviour _enemyPrefab;

        [SerializeField] 
        private EnemySettings _enemySettings;

        [Space, SerializeField] 
        private ProjectileBehaviour _projectilePrefab;

        [SerializeField] 
        private ProjectileSettings _projectileSettings;

        [Space, SerializeField] 
        private PlayerSettings _playerSettings;

        [Space, SerializeField] 
        private FieldSettings _fieldSettings;

        public override void InstallBindings()
        {
            InstallGameLogic();
            InstallEnemiesLogic();
            InstallProjectilesLogic();
            InstallPlayerLogic();
            InstallEvents();
        }

        private void InstallGameLogic()
        {
            Container
                .Bind<ISpawnPointsProvider>()
                .FromSubContainerResolve()
                .ByNewContextPrefab(_gameField)
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IFieldResetter>()
                .FromSubContainerResolve()
                .ByNewContextPrefab(_gameField)
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesTo<EnemyNumberProvider>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesTo<EnemyTimer>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesTo<EnemySpawner>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesTo<EnemySpawnPointProvider>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<GameController>()
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<IFactory<IGameSession>>()
                .To<GameSessionFactory>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindMemoryPool<IGameSession, GameSession.Pool>()
                .To<GameSession>()
                .NonLazy();
            
            Container
                .Bind<IMemoryPool<IGameSession>>()
                .To<GameSession.Pool>()
                .FromResolve();
            
            Container
                .Bind<FieldSettings>()
                .FromInstance(_fieldSettings)
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IPlayerRunner>()
                .FromSubContainerResolve()
                .ByNewContextPrefab(_player)
                .AsSingle()
                .NonLazy();
        }

        private void InstallEnemiesLogic()
        {
            Container
                .Bind<EnemySettings>()
                .FromInstance(_enemySettings)
                .AsSingle()
                .NonLazy();
            
            Container
                .BindMemoryPool<EnemyBehaviour, EnemyBehaviour.Pool>()
                .WithInitialSize(_enemySettings.MinEnemiesNumber)
                .FromComponentInNewPrefab(_enemyPrefab)
                .UnderTransformGroup("Enemies")
                .NonLazy();
            
            Container
                .Bind<IMemoryPool<EnemyBehaviour>>()
                .To<EnemyBehaviour.Pool>()
                .FromResolve();
            
            Container
                // .BindIFactory<>()
                .Bind<IFactory<Vector2, OnDeath, EnemyBehaviour>>()
                .To<EnemyFactory>()
                .AsSingle()
                .NonLazy();

            // Container
            //     .BindIFactory<Vector2, OnDeath, EnemyBehaviour, IFactory<Vector2, OnDeath, EnemyBehaviour>>()
            //     .To<EnemyFactory>()
            //     .FromSubContainerResolve()
            //     .ByNewContextPrefab<EnemyInstaller>(_enemyPrefab);
        }

        private void InstallProjectilesLogic()
        {
            Container
                .Bind<ProjectileSettings>()
                .FromInstance(_projectileSettings)
                .AsSingle()
                .NonLazy();
            
            Container
                .BindMemoryPool<ProjectileBehaviour, ProjectileBehaviour.Pool>()
                .WithInitialSize(_enemySettings.MinEnemiesNumber)
                .FromComponentInNewPrefab(_projectilePrefab)
                .UnderTransformGroup("Projectiles")
                .NonLazy();
            
            Container
                .Bind<IMemoryPool<ProjectileBehaviour>>()
                .To<ProjectileBehaviour.Pool>()
                .FromResolve();
            
            Container
                .Bind<IFactory<ProjectileData, ProjectileBehaviour>>()
                .To<ProjectileFactory>()
                .AsSingle()
                .NonLazy();
        }

        private void InstallPlayerLogic()
        {
            Container
                .Bind<PlayerSettings>()
                .FromInstance(_playerSettings)
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<InputMap>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<InputManager>()
                .AsSingle()
                .NonLazy();
        }
        
        private void InstallEvents()
        {
            Container
                .Bind<IEventBus>()
                .To<EventBus>()
                .AsSingle()
                .OnInstantiated<IEventBus>((ctx, bus) =>
                {
                    var types = AppDomain.CurrentDomain
                        .GetAssemblies()
                        .SelectMany(s => s.GetTypes())
                        .Where(p => typeof(IEvent).IsAssignableFrom(p)
                                    && !p.IsInterface
                                    && !p.IsAbstract);
                    
                    foreach (var type in types)
                    {
                        bus.Register(type);
                    }
                })
                .NonLazy();
        }
    }
}