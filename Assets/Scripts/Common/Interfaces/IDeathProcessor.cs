namespace Common
{
    public interface IDeathProcessor
    {
        void SetOnDeath(OnDeath onDeath); // lol 
        void OnDeath();
    }
}