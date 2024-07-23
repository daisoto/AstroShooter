using System;
using UniRx;

namespace Common
{
    public class LifeController: ISetupable
    {
        private readonly IHealthComponent _health;
        private readonly IDeathProcessor _deathProcessor;

        public LifeController(IHealthComponent health, IDeathProcessor deathProcessor)
        {
            _health = health;
            _deathProcessor = deathProcessor;
        }

        public IDisposable Setup()
        {
            return _health
                .Health
                .Subscribe(h =>
                {
                    if (h < 1)
                    {
                        _deathProcessor.OnDeath();
                    }
                });
        }
    }
}