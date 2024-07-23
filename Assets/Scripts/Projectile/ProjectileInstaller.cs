using Common;
using UnityEngine;
using Zenject;

namespace Projectile
{
    public class ProjectileInstaller: MonoInstaller<ProjectileInstaller>
    {
        [SerializeField] 
        private Animator _animator;

        [SerializeField] 
        private ProjectileBehaviour _behaviour;

        [SerializeField] 
        private Rigidbody2D _rigidbody;

        [SerializeField] 
        private ProjectileDamageDealer _damageDealer;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<ProjectileBehaviour>()
                .FromInstance(_behaviour)
                .AsSingle()
                .NonLazy();
                
            Container
                .BindInterfacesTo<ProjectileAnimator>()
                .AsSingle()
                .WithArguments(_animator)
                .NonLazy();
            
            Container
                .BindInterfacesTo<PositionSetter>()
                .AsSingle()
                .WithArguments(_behaviour.transform)
                .NonLazy();
            
            Container
                .BindInterfacesTo<ProjectileDamageDealer>()
                .FromInstance(_damageDealer)
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesTo<ProjectileMoveProvider>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesTo<Mover>()
                .AsSingle()
                .WithArguments(_rigidbody)
                .NonLazy();
            
            Container
                .BindInterfacesTo<MoveController>()
                .AsSingle()
                .NonLazy();
        }
    }
}