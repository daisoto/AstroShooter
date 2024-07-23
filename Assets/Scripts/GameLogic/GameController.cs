using System;
using Common;
using Field;
using GameLogic.Interfaces;
using Player;
using UniRx;
using UnityEngine;
using Zenject;

namespace GameLogic
{
    public class GameController: IInitializable, IDisposable
    {
        private readonly IEventBus _bus;
        private readonly IFactory<IGameSession> _sessionFactory;
        private readonly IPlayerRunner _playerRunner;
        private readonly IFieldResetter _fieldResetter;
        private readonly ISetupable[] _setupables;

        private IGameSession _currentSession;
        private IDisposable _sub;
        private IDisposable _setupSub;

        public GameController(IEventBus bus, IFactory<IGameSession> sessionFactory, 
            IFieldResetter fieldResetter, IPlayerRunner playerRunner, ISetupable[] setupables)
        {
            _bus = bus;
            _sessionFactory = sessionFactory;
            _fieldResetter = fieldResetter;
            _playerRunner = playerRunner;
            _setupables = setupables;
        }

        public void Initialize()
        {
            var cd = new CompositeDisposable();
            
            _bus
                .Subscribe<StartGameEvent>(_ =>
                {
                    if (_currentSession is { IsActive: true })
                    {
                        Debug.LogWarning("Previous session was not finished! Aborting.");
                        StopGame();
                    }

                    StartGame();
                })
                .AddTo(cd);

            _bus
                .Subscribe<WinGameEvent>(_ => StopGame())
                .AddTo(cd);

            _bus
                .Subscribe<LoseGameEvent>(_ => StopGame())
                .AddTo(cd);

            _sub = cd;
            
            _bus.Dispatch(new StartGameEvent());
        }

        public void Dispose() => _sub.Dispose();

        private void StartGame()
        {
            var cd = new CompositeDisposable();
            Array.ForEach(_setupables, s => s.Setup().AddTo(cd)); 
            _setupSub = cd;
            
            _currentSession = _sessionFactory.Create();
            _currentSession.Start();
            _playerRunner.Run();
            _fieldResetter.Reset();
        }

        private void StopGame()
        {
            _currentSession.Stop();
            _playerRunner.Stop();
            _setupSub?.Dispose();
        }
    }
}