using Cysharp.Threading.Tasks;

namespace Enemy
{
    public interface IEnemyAnimator
    {
        void PlayMove();
        UniTask PlayDamaged();
        UniTask PlayDeath();
    }
}