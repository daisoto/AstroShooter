namespace GameLogic.Interfaces
{
    public interface IGameSession
    {
        bool IsActive { get; }
        void Start();
        void Stop();
        void SetEnemiesNum(int num);
    }
}