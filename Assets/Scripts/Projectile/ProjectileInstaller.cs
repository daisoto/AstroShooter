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
                .WithArguments(_rigidbody)
                .NonLazy();
            
            Container
                .BindInterfacesTo<ProjectileDamageDealer>()
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