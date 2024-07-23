using Common;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Projectile
{
    public class ProjectileAnimator: IProjectileAnimator
    {
        private readonly Animator _animator;
        
        private static int EXPLODE_KEY = Animator.StringToHash("Hit-4 Animation");

        public ProjectileAnimator(Animator animator)
        {
            _animator = animator;
        }

        public async UniTask PlayExplode()
        {
            _animator.SetTrigger(EXPLODE_KEY);
            await _animator.WaitAnimationToEnd(0);
        }
    }
}