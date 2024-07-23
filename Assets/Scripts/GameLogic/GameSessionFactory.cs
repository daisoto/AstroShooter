using GameLogic.Interfaces;
using Zenject;

namespace GameLogic
{
    public class GameSessionFactory: IFactory<IGameSession>
    {
        private readonly IEnemyNumberProvider _enemyNumberProvider;
        private readonly IMemoryPool<IGameSession> _pool;

        public GameSessionFactory(IEnemyNumberProvider enemyNumberProvider, IMemoryPool<IGameSession> pool)
        {
            _enemyNumberProvider = enemyNumberProvider;
            _pool = pool;
        }

        public IGameSession Create()
        {
            var enemyNum = _enemyNumberProvider.GetEnemyNumber();
            var session = _pool.Spawn();
            session.SetEnemiesNum(enemyNum);

            return session;
        }
    }
}