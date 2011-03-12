using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using System.Collections;

namespace System.Runtime.CompilerServices
{
    [AttributeUsageAttribute(
      AttributeTargets.Assembly
      | AttributeTargets.Class
      | AttributeTargets.Method)]
    public sealed class ExtensionAttribute : Attribute { }
}

namespace Netduino.BurglarAlarm
{
    public static class TimeSpanExtensions
    {
        public static int GetTotalMilliseconds(this TimeSpan span)
        {
            return span.Seconds * 1000 + span.Milliseconds;
        }
    }
}
