using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using System.Collections;

namespace Netduino.BurglarAlarm
{
    class StandByState : IState
    {
        public event StateChangedEventArgs StateChanged;
        private BaseBoard board;

        public StandByState(BaseBoard board)
        {
            this.board = board;        
        }

        public void OnPressed()
        {
            board.Led.Blink(100);
        }

        public void OnReleased()
        {
            if (StateChanged != null)
            {
                StateChanged(new AlarmSetState(board));
            }
        }

        public void OnMotion()
        {
        }

        public void Start()
        {
        }
    }
}
