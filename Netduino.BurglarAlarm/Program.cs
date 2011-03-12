using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Netduino.BurglarAlarm
{
    /// <summary>
    /// To run this - set up circuit with a speaker and PIR sensor
    /// Pressing the onboard button sets the alarm
    /// when movement is detected, the speaker sounds until the button is pressed 3 times to disable
    /// 
    /// Using some code from Joaquin Jares blog 'Playing with Netduino' Saturday, October 09, 2010 7:25 PM
    ///  http://geekswithblogs.net/osnosblog/archive/2010/10/09/142211.aspx
    //
    /// </summary>    
    public class Program
    {
        private static BaseBoard board;
        private static IState state;

        public static void Main()
        {
            Debug.Print("Sleeping until PIR stablises, about 10 seconds.");
            Thread.Sleep(10000);
            Debug.Print("Ready....");

            board = new BaseBoard();
            board.Button.Pressed += OnPressedEvent;
            board.Button.Released += OnReleasedEvent;
            board.Sensor.DetectedMotion += OnMotionEvent;

            state = new StandByState(board);
            state.StateChanged += state_StateChanged;

            Thread.Sleep(Timeout.Infinite);
        }

        static void state_StateChanged(IState newState)
        {
            state.StateChanged -= state_StateChanged;
            state = newState;
            state.StateChanged += state_StateChanged;
            state.Start();
        }

        static void OnPressedEvent()
        {
            state.OnPressed();
        }

        static void OnReleasedEvent()
        {
            state.OnReleased();
        }

        static void OnMotionEvent()
        {
            state.OnMotion();
        }

    }
}
