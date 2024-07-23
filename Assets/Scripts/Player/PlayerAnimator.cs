using UnityEngine;

namespace Player
{
    public class PlayerAnimator: IPlayerAnimator
    {
        private static int MOVE_KEY = Animator.StringToHash("Move");
        
        private readonly Animator _animator;

        public PlayerAnimator(Animator animator)
        {
            _animator = animator;
        }

        public void PlayMove()
        {
            throw new System.NotImplementedException();
        }

        public void PlayIdle()
        {
            throw new System.NotImplementedException();
        }
    }
}