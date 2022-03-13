using System;

namespace SimpleStrategy3D.Abstractions
{
    public interface ITimeModel 
    {
        IObservable<int> GameTime { get; }
    }
}
