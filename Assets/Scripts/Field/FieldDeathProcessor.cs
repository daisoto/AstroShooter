using Common;

namespace Field
{
    public class FieldDeathProcessor: IDeathProcessor
    {
        private OnDeath _onDeath;
        
        public void SetOnDeath(OnDeath onDeath)
        {
            _onDeath = onDeath;
        }

        public void OnDeath()
        {
            throw new System.NotImplementedException();
        }
    }
}