using Common;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public class EnemyInstaller: MonoInstaller<EnemyInstaller>
    {
        [SerializeField] 
        private Animator _animator;
        
        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField] 
        private CollisionProcessor _enemyCollisionProcessor;

        [SerializeField] 
        private EnemyBehaviour _behaviour;

        [SerializeField] 
        private EnemyDamageDealer _damageDealer;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<HealthComponent>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesTo<EnemyDeathProcessor>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesTo<LifeController>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesTo<EnemyMoveProvider>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesTo<Mover>()
                .AsSingle()
                .WithArguments(_rigidbody)
                .NonLazy();
            
            Container
                .BindInterfacesTo<PositionSetter>()
                .AsSingle()
                .WithArguments(_behaviour.transform)
                .NonLazy();
            
            Container
                .BindInterfacesTo<MoveController>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesTo<EnemyDamageReceiver>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesTo<EnemyDamageDealer>()
                .FromInstance(_damageDealer)
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<CollisionProcessor>()
                .FromInstance(_enemyCollisionProcessor)
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<EnemyBehaviour>()
                .FromInstance(_behaviour)
                .AsSingle()
                .NonLazy();
                
            Container
                .BindInterfacesTo<EnemyAnimator>()
                .AsSingle()
                .WithArguments(_animator)
                .NonLazy();
        }
    }
}