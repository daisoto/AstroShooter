using Common;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerInstaller: MonoInstaller<PlayerInstaller>
    {
        [SerializeField] 
        private Animator _mainAnimator;
        
        [SerializeField] 
        private Animator _weaponAnimator;

        [SerializeField] 
        private PlayerBehaviour _behaviour;

        [SerializeField] 
        private Rigidbody2D _rigidbody;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<PlayerAnimator>()
                .AsSingle()
                .WithArguments(_mainAnimator)
                .NonLazy();
                
            Container
                .BindInterfacesTo<PlayerWeaponAnimator>()
                .AsSingle()
                .WithArguments(_weaponAnimator)
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<PlayerBehaviour>()
                .FromInstance(_behaviour)
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesTo<Mover>()
                .AsSingle()
                .WithArguments(_rigidbody)
                .NonLazy();
            
            Container
                .BindInterfacesTo<PlayerMoveProvider>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesTo<MoveController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesTo<EnemyDetector>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesTo<ShootingRateTimer>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesTo<Shooter>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesTo<PlayerShootController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesTo<PlayerRunner>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesTo<PositionSetter>()
                .AsSingle()
                .WithArguments(_behaviour.transform)
                .NonLazy();

            Container
                .BindInterfacesTo<PlayerPositionProvider>()
                .AsSingle()
                .WithArguments(_behaviour.transform)
                .NonLazy();
        }
    }
}