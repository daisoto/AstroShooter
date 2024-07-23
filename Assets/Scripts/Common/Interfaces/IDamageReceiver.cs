namespace Common
{
    public interface IDamageReceiver
    {
        void Receive(int damage);

        DamageReceiverType Type { get; }
    }
}