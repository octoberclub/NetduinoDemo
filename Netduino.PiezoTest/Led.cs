using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

public class Led
{
    private Cpu.Pin pin;
    private OutputPort led;

    private bool state;

    public Led(Cpu.Pin pin)
    {
        this.pin = pin;
        this.state = false;
        this.led = new OutputPort(pin, state);
    }

    public bool State
    {
        get
        {
            return state;
        }
        set
        {
            state = value;
            led.Write(state);
        }
    }

    public void TurnOn()
    {
        State = true;
    }

    public void TurnOff()
    {
        State = false;
    }

    public void Invert()
    {
        State = !State;
    }

    internal void Blink(int time)
    {
        TurnOn();
        Thread.Sleep(time);
        TurnOff();
    }
}
