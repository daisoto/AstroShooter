using UnityEngine;

namespace Enemy
{
    public class EnemyAnimator: IEnemyAnimator
    {
        private readonly Animator _animator;

        private static int MOVE_KEY = Animator.StringToHash("bomb_walk_down");
        private static int DAMAGED_KEY = Animator.StringToHash("hit_A_down");
        private static int DEATH_KEY = Animator.StringToHash("vanish");

        public EnemyAnimator(Animator animator)
        {
            _animator = animator;
        }

        public void PlayMove()
        {
            _animator.SetTrigger(MOVE_KEY);
        }

        public void PlayDamaged()
        {
            _animator.SetTrigger(DAMAGED_KEY);
        }

        public void PlayDeath()
        {
            _animator.SetTrigger(DEATH_KEY);
        }
    }
}