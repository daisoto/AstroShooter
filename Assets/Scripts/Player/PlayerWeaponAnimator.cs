using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Player
{
    public class PlayerWeaponAnimator: IPlayerWeaponAnimator
    {
        private readonly Animator _animator;

        public PlayerWeaponAnimator(Animator animator)
        {
            _animator = animator;
        }

        public UniTask PlayShoot()
        {
            throw new System.NotImplementedException();
        }
    }
}