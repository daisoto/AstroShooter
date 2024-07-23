using Common;
using Cysharp.Threading.Tasks;

namespace Enemy
{
    public class EnemyDeathProcessor: IDeathProcessor
    {
        private readonly IEnemyAnimator _animator;
        private readonly IDespawnable _despawnable;

        private OnDeath _onDeath;

        public EnemyDeathProcessor(IEnemyAnimator animator)
        {
            _animator = animator;
        }

        public void SetOnDeath(OnDeath onDeath)
        {
            _onDeath = onDeath;
        }

        public void OnDeath() => OnDeathInternal().Forget();

        private async UniTask OnDeathInternal()
        {
            _onDeath?.Invoke();
            await _animator.PlayDeath();
            _despawnable.Despawn();
        }
    }
}