using System.Collections.Generic;
using Common;
using Cysharp.Threading.Tasks;

namespace Enemy
{
    public class EnemyDamageReceiver: IEnemyDamageReceiver
    {
        private readonly IHealthComponent _health;
        private readonly IEnemyAnimator _animator;
        private readonly IEnemyMoveProvider _enemyMoveProvider;
        
        private readonly Queue<int> _damageReceived;
        private bool _isProcessing;

        public EnemyDamageReceiver(IHealthComponent health, IEnemyAnimator animator, 
            IEnemyMoveProvider enemyMoveProvider)
        {
            _health = health;
            _animator = animator;
            _enemyMoveProvider = enemyMoveProvider;

            _damageReceived = new();
        }

        public void Receive(int damage)
        {
            if (_health.Health.Value > 0)
            {
                _damageReceived.Enqueue(damage);
                if (!_isProcessing)
                {
                    ProcessDamage().Forget();
                }
            }
        }

        public DamageReceiverType Type => DamageReceiverType.Enemy;

        // todo animator is shit
        private async UniTask ProcessDamage()
        {
            _isProcessing = true;
            _enemyMoveProvider.SetInterrupted(true);

            while (_damageReceived.Count > 0)
            {
                var damage = _damageReceived.Dequeue();
                if (_health.Health.Value > 0)
                {
                    _health.Decrease(damage);
                    await _animator.PlayDamaged();
                }
            }

            _isProcessing = false;
            _enemyMoveProvider.SetInterrupted(false);
            _animator.PlayMove(); // todo ?
        } 
    }
}