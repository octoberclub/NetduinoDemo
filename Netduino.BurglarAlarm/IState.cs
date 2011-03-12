using System;
namespace Netduino.BurglarAlarm
{
    public delegate void StateChangedEventArgs(IState state);

    public interface IState
    {
        void OnPressed();
        void OnReleased();
        void OnMotion();
        void Start();
        event StateChangedEventArgs StateChanged;
    }
}
