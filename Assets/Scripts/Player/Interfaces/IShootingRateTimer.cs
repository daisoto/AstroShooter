using Common;

namespace Player
{
    public interface IShootingRateTimer: ISetupable
    {
        bool CanShoot { get; }
        void Reset();
        void SetRate(float rate);
    }
}