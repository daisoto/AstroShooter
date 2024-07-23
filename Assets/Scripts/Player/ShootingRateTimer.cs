using System;
using UniRx;
using UnityEngine;

namespace Player
{
    public class ShootingRateTimer: IShootingRateTimer
    {
        public bool CanShoot { get; private set; }

        private float _time;
        private float _timeout;
        
        public IDisposable Setup()
        {
            return Observable
                .EveryUpdate()
                .Subscribe(_ => Tick());
        }

        public void SetTimeout(float timeout)
        {
            _timeout = timeout;
        }

        public void Reset()
        {
            CanShoot = false;
            _time = 0;
        }

        private void Tick()
        {
            _time += Time.deltaTime;

            if (_time >= _timeout)
            {
                CanShoot = true;
            }
        }
    }
}