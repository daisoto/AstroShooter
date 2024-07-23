using Cysharp.Threading.Tasks;

namespace Projectile
{
    public interface IProjectileAnimator
    {
        UniTask PlayExplode();
    }
}