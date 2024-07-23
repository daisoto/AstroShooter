using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common
{
    public static class AnimatorExtension
    {
        public static async UniTask WaitAnimationToEnd(this Animator animator, int layer)
        {
            while (animator.GetCurrentAnimatorStateInfo(layer).normalizedTime < 1f)
            {
                await UniTask.Yield();
            }
        }
    }
}