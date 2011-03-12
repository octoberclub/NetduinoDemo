using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

public class PiezoSpeaker
{
    private PWM _pin;
    
    public PiezoSpeaker(Cpu.Pin pin)
    {
        _pin = new PWM(pin);

        TurnOff();
    }

    public void TurnOn()
    {
        uint period = 1654;
        _pin.SetPulse(period, period / 2);
    
    }

    public void TurnOff()
    {
        // take the pin low, so the speaker
        // doesn't make any noise until we
        // ask it to
        _pin.SetDutyCycle(0);    
    }
}
