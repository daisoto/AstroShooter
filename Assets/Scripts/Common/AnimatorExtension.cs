using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common
{
    public static class AnimatorExtension
    {
        public static async UniTask WaitAnimationToEnd(this Animator animator, int layer)
        {
            var length = animator.GetCurrentAnimatorStateInfo(layer).length;
            await UniTask.WaitForSeconds(length);
        }
    }
}