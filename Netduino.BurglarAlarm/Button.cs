using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

public delegate void NoParamEventHandler();

public class Button
{
    private InterruptPort port;
    private Cpu.Pin pin;
    public event NoParamEventHandler Pressed;
    public event NoParamEventHandler Released;

    public Button(Cpu.Pin pin)
    {
        this.pin = pin;
        this.port = new InterruptPort(pin, false, Port.ResistorMode.Disabled, Port.InterruptMode.InterruptEdgeBoth);
        this.port.OnInterrupt += new NativeEventHandler(port_OnInterrupt);
    }

    public bool IsPressed
    {
        get
        {
            return !port.Read();
        }
    }

    void port_OnInterrupt(uint data1, uint data2, DateTime time)
    {
        if (data2 == 0)
        {
            OnPressed();
        }
        else
        {
            OnReleased();
        }
    }

    private void OnReleased()
    {
        if (Released != null)
        {
            Released();
        }
    }

    private void OnPressed()
    {
        if (Pressed != null)
        {
            Pressed();
        }
    }
}
