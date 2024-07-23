using Common;

namespace Player
{
    public interface IShootingRateTimer: ISetupable
    {
        bool CanShoot { get; }
        void Reset();
        void SetTimeout(float timeout);
    }
}