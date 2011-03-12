using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using System.Collections;

namespace Netduino.BurglarAlarm
{
    // Alarm is set. Waiting to detect motion or code input to disable
    class AlarmSetState : IState
    {
        public event StateChangedEventArgs StateChanged;
        private BaseBoard board;
        private int buttonCount;

        public AlarmSetState(BaseBoard board)
        {
            this.board = board;
        }

        public void OnPressed()
        {
            board.Led.Blink(200);
            buttonCount++;
        }

        public void OnReleased()
        {            
            if (buttonCount > 3)
            {
                // disable the alarm and set to StandByMode
                this.board.Speaker.TurnOff();
                this.board.Led.Blink(200);
                this.board.Led.Blink(200);
                if (StateChanged != null)
                {
                    StateChanged(new StandByState(board));
                    board.Sensor.TurnOff();
                }                
            }        
        }

        public void OnMotion()
        {
            this.board.Led.TurnOn();
            this.board.Speaker.TurnOn();
        }

        public void Start()
        {
            board.Sensor.TurnOn();
        }

 
    }
}
