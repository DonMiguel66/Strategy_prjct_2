using SimpleStrategy3D.Abstractions;
using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace SimpleStrategy3D.Core
{
    public class TimeModel : ITimeModel, ITickable
    {
        public IObservable<int> GameTime => _gameTime.Select(f => (int)f);
        private ReactiveProperty<float> _gameTime = new ReactiveProperty<float>();

        public void Tick()
        {
            _gameTime.Value += Time.deltaTime;
        }
    }
}

