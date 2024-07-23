using System;
using UniRx;
using UnityEngine;

namespace Player
{
    public class ShootingRateTimer: IShootingRateTimer
    {
        public bool CanShoot { get; private set; }

        private float _time;
        private float _rate;
        
        public IDisposable Setup()
        {
            return Observable
                .EveryUpdate()
                .Subscribe(_ => Tick());
        }

        public void SetRate(float rate)
        {
            _rate = rate;
        }

        public void Reset()
        {
            CanShoot = false;
            _time = 0;
        }

        private void Tick()
        {
            _time += Time.deltaTime;

            if (_time >= _rate)
            {
                CanShoot = true;
            }
        }
    }
}