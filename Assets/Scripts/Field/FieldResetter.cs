using Common;
using GameLogic;
using GameLogic.Interfaces;
using Settings;

namespace Field
{
    public class FieldResetter: IFieldResetter
    {
        private readonly GameField _field;
        private readonly FieldSettings _fieldSettings;
        private readonly IEventBus _eventBus;

        public FieldResetter(FieldSettings fieldSettings, GameField field, IEventBus eventBus)
        {
            _fieldSettings = fieldSettings;
            _field = field;
            _eventBus = eventBus;
        }

        public void Reset()
        {
            _field
                .SetHealth(_fieldSettings.Health)
                .SetOnDeath(() => _eventBus.Dispatch(new PlayerKilledEvent()));
        }
    }
}