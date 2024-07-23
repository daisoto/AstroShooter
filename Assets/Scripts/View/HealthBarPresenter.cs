using System;
using Common;
using UniRx;
using Zenject;

namespace View
{
    public class HealthBarPresenter: IInitializable, IDisposable
    {
        private readonly HealthBarView _view;
        private readonly IHealthComponent _healthComponent;

        private IDisposable _dis;

        public HealthBarPresenter(HealthBarView view, IHealthComponent healthComponent)
        {
            _view = view;
            _healthComponent = healthComponent;
        }

        public void Initialize()
        {
            _dis = _healthComponent
                .Health
                .Subscribe(_view.SetHealth);
        }

        public void Dispose() => _dis.Dispose();
    }
}