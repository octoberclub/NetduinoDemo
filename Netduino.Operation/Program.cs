using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Netduino.Operation
{
    public class Program
    {
        public static void Main()
        {
            // write your code here
            var led = new OutputPort(Pins.ONBOARD_LED, false);
            var input = new InputPort(Pins.GPIO_PIN_D7, true, Port.ResistorMode.Disabled);

            while (true)
            {
                Debug.Print("input=" + input.Read().ToString());
                led.Write(!input.Read());
                Thread.Sleep(100);
            }
        }

    }
}
