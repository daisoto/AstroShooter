namespace Common
{
    public interface IDeathProcessor
    {
        void SetOnPreDeath(OnDeath onDeath);
        void SetOnAfterDeath(OnDeath onDeath); 
        void OnDeath();
    }
}