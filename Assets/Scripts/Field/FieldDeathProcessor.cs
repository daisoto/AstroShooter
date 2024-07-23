using Common;

namespace Field
{
    public class FieldDeathProcessor: IDeathProcessor
    {
        private OnDeath _onDeath;
        
        public void SetOnPreDeath(OnDeath onDeath)
        {
            _onDeath = onDeath;
        }

        public void SetOnAfterDeath(OnDeath onDeath)
        { }

        public void OnDeath()
        {
            _onDeath?.Invoke();
        }
    }
}