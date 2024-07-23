namespace Common
{
    public interface IDamageDealer
    {
        void TryDeal(IDamageReceiver receiver);
    }

    public interface IDamageDealerConfigurable: IDamageDealer
    {
        void SetDamageDealt(int damage);
    }
}