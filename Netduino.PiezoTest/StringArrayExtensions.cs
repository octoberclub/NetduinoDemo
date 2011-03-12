using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace System.Runtime.CompilerServices
{
    [AttributeUsageAttribute(
      AttributeTargets.Assembly
      | AttributeTargets.Class
      | AttributeTargets.Method)]
    public sealed class ExtensionAttribute : Attribute { }
}    

namespace LED.ExtensionMethods
{
    public static class StringArrayExtensions
    {
        public static int IndexOf(this string[] arr, string key)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (key == arr[i]) return i;
            }
            return -1;
        }
    }
}
