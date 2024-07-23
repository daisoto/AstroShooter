using Cysharp.Threading.Tasks;

namespace Player
{
    public interface IPlayerWeaponAnimator
    {
        UniTask PlayShoot();
    }
}