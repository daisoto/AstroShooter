namespace Enemy
{
    public interface IEnemyAnimator
    {
        void PlayMove();
        void PlayDamaged();
        void PlayDeath();
    }
}