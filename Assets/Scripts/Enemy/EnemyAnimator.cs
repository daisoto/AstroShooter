using Common;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Enemy
{
    public class EnemyAnimator: IEnemyAnimator
    {
        private readonly Animator _animator;

        private static int MOVE_KEY = Animator.StringToHash("Move");
        private static int DAMAGED_KEY = Animator.StringToHash("Damaged");
        private static int DEATH_KEY = Animator.StringToHash("Death");

        public EnemyAnimator(Animator animator)
        {
            _animator = animator;
        }

        public void PlayMove()
        {
            _animator.SetTrigger(MOVE_KEY);
        }

        public async UniTask PlayDamaged()
        {
            _animator.SetTrigger(DAMAGED_KEY);
            await _animator.WaitAnimationToEnd(0);
        }

        public async UniTask PlayDeath()
        {
            _animator.SetTrigger(DEATH_KEY);
            await _animator.WaitAnimationToEnd(0);
        }
    }
}