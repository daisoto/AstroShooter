using System;
using GameLogic;
using GameLogic.Interfaces;
using UniRx;
using Zenject;

namespace View
{
    public class MenuPresenter: IInitializable, IDisposable
    {
        private readonly MenuView _view;
        private readonly IEventBus _bus;

        private IDisposable _sub;

        public MenuPresenter(MenuView view, IEventBus bus)
        {
            _view = view;
            _bus = bus;
        }

        public void Initialize()
        {
            var cd = new CompositeDisposable();

            _bus
                .Subscribe<LoseGameEvent>(_ => OnLose())
                .AddTo(cd);

            _bus
                .Subscribe<WinGameEvent>(_ => OnWin())
                .AddTo(cd);

            _view
                .RestartButton
                .OnClickAsObservable()
                .Subscribe(_ => Restart())
                .AddTo(cd);

            _sub = cd;
        }

        public void Dispose() => _sub.Dispose();

        private void OnLose()
        {
            _view.SetLose();
            _view.Show();
        }

        private void OnWin()
        {
            _view.SetWin();
            _view.Show();
        }

        private void Restart()
        {
            _view.Hide();
            _bus.Dispatch(new StartGameEvent());
        }
    }
}