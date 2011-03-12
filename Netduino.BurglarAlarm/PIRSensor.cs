using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

public class PIRSensor
{
    private InterruptPort port;

    public event NoParamEventHandler DetectedMotion;


    public PIRSensor(Cpu.Pin pin)
    {
        this.port = new InterruptPort(pin, false, Port.ResistorMode.Disabled, Port.InterruptMode.InterruptEdgeBoth);
    }

    public void TurnOn()
    {
        port.OnInterrupt += new NativeEventHandler(port_OnInterrupt);
    }

    public void TurnOff()
    {
        port.OnInterrupt -= new NativeEventHandler(port_OnInterrupt);
    }

    void port_OnInterrupt(uint data1, uint data2, DateTime time)
    {
        DetectedMotion();
    }
}
