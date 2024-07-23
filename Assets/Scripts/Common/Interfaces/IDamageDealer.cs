namespace Common
{
    public interface IDamageDealer
    {
        void SetDamageDealt(int damage);
        void TryDeal(IDamageReceiver receiver);
    }
}