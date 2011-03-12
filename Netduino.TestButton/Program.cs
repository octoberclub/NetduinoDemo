using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Netduino.TestButton
{
    public class Program
    {        
        public static void Main()
        {
            // write your code here 
            var led=new OutputPort(Pins.ONBOARD_LED, false);
            
            var button = new InputPort(Pins.ONBOARD_SW1, false, Port.ResistorMode.Disabled);
            while (true)
            {
                if (!button.Read())
                {
                    led.Write(!led.Read());
                    Thread.Sleep(300);
                }
            }
        }
    }
}
