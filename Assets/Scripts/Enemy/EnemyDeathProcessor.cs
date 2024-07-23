using Common;
using Cysharp.Threading.Tasks;

namespace Enemy
{
    public class EnemyDeathProcessor: IDeathProcessor
    {
        private readonly IEnemyAnimator _animator;

        private OnDeath _onPreDeath;
        private OnDeath _onAfterDeath;

        public EnemyDeathProcessor(IEnemyAnimator animator)
        {
            _animator = animator;
        }

        public void SetOnPreDeath(OnDeath onDeath)
        {
            _onPreDeath = onDeath;
        }

        public void SetOnAfterDeath(OnDeath onDeath)
        {
            _onAfterDeath = onDeath;
        }

        public void OnDeath() => OnDeathInternal().Forget();

        private async UniTask OnDeathInternal()
        {
            _onPreDeath?.Invoke();
            await _animator.PlayDeath();
            _onAfterDeath?.Invoke();
        }
    }
}