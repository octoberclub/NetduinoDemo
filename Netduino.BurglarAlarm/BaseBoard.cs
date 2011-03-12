using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

public class BaseBoard
{
    public Button Button { get; private set; }
    public Led Led { get; private set; }
    public PiezoSpeaker Speaker { get; private set; }

    public PIRSensor Sensor{ get; private set; }

    public BaseBoard()
    {
        Button = new Button(Pins.ONBOARD_SW1);
        Led = new Led(Pins.ONBOARD_LED);
        Speaker = new PiezoSpeaker(Pins.GPIO_PIN_D5);
        Sensor = new PIRSensor(Pins.GPIO_PIN_D13);
    }
}