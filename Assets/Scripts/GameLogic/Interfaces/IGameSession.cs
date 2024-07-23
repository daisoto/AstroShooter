using Zenject;

namespace GameLogic.Interfaces
{
    public interface IGameSession: IPoolable<IMemoryPool<IGameSession>>
    {
        bool IsActive { get; }
        void Start();
        void Stop();
        void SetEnemiesNum(int num);
    }
}