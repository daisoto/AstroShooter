using Common;

namespace Enemy
{
    public interface IEnemyMoveProvider: IMoveProvider
    {
        void SetInterrupted(bool flag);
    }
}