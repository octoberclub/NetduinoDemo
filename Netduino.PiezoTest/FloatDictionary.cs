using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

using LED.ExtensionMethods;

/// <summary>
/// Micro Framework does not contain a dictionary object (or generics!!!)
/// This is a basic dictionary that holds float values against a string key.
/// </summary>
public class FloatDictionary
{
    private string[] _keys;
    private float[] _values;
    private int _count = 0;

    private int _initialSize;
    private int _growBy;

    public FloatDictionary(int initialSize, int growBy)
    {
        _initialSize = initialSize;
        _growBy = growBy;

        _keys = new string[initialSize];
        _values = new float[initialSize];
    }

    /// <summary>
    /// Add a value to the dictionary. If the key already
    /// exists, the new value is ignored
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public FloatDictionary Add(string key, float value)
    {
        if (_keys.IndexOf(key) == -1)
        {
            _keys[_count] = key;
            _values[Count] = value;

            _count++;

            // There's probably a better way to do this but for now
            // if we reach the current capacity of the arrays, we need
            // to create new arrays with a new larger size and copy
            // the contents of the old arrays to the new.
            if (_count == _keys.Length)
            {
                string[] newKeys = new string[_count + _growBy];
                float[] newValues = new float[_count + _growBy];

                for (int n = 0; n < _count; n++)
                {
                    newKeys[n] = _keys[n];
                    newValues[n] = _values[n];
                }

                _keys = newKeys;
                _values = newValues;
            }
        }

        return this;
    }

    /// <summary>
    /// Check to see if dictionary contains the key
    /// </summary>
    /// <param name="key">String key</param>
    /// <returns>Boolean</returns>
    public bool ContainsKey(string key)
    {
        return Array.IndexOf(_keys, key) != -1;
    }

    /// <summary>
    ///  Returns the key for the item at position "position"
    ///  If the position is outside the array limits, null is returned
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public string GetKey(int position)
    {
        if (position < 0 || position >= _count)
            return null;
        else
            return _keys[position];
    }

    /// <summary>
    /// Return the value for the supplied key
    /// If the key doesn't exist, return null
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public object GetValue(string key)
    {
        int position = Array.IndexOf(_keys, key);

        if (position == -1)
            return null;
        else
            return _values[position];
    }

    public int Count
    {
        get { return _count; }
    }
}
