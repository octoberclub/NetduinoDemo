using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

//Next is a class that exposes a static array of FloatDictionary objects that store the frequency information for seven octaves of notes.

public class NoteFrequencies
{
    public static FloatDictionary[] Octaves = new FloatDictionary[] 
        {
            new FloatDictionary(17,10)      // C0
                .Add("c", 16.35f)
                .Add("c#", 17.32f)
                .Add("db", 17.32f)
                .Add("d", 18.35f)
                .Add("d#", 19.45f)
                .Add("eb", 19.45f)
                .Add("e", 20.6f)
                .Add("f", 21.83f)
                .Add("f#", 23.12f)
                .Add("gb", 23.12f)
                .Add("g", 24.5f)
                .Add("g#", 25.96f)
                .Add("ab", 25.96f)
                .Add("a", 27.5f)
                .Add("a#", 29.14f)
                .Add("bb", 29.14f)
                .Add("b", 30.87f),

            new FloatDictionary(17,10)      // C1
                .Add("c", 32.7f)
                .Add("c#", 34.65f)
                .Add("db", 34.65f)
                .Add("d", 36.71f)
                .Add("d#", 38.89f)
                .Add("eb", 38.89f)
                .Add("e", 41.2f)
                .Add("f", 43.65f)
                .Add("f#", 46.25f)
                .Add("gb", 46.25f)
                .Add("g", 49.0f)
                .Add("g#", 51.91f)
                .Add("ab", 51.91f)
                .Add("a", 55.0f)
                .Add("a#", 58.27f)
                .Add("bb", 58.27f)
                .Add("b", 61.74f),
                
            new FloatDictionary(17,10)      // C2
                .Add("c", 65.41f)
                .Add("c#", 69.3f)
                .Add("db", 69.3f)
                .Add("d", 73.42f)
                .Add("d#", 77.78f)
                .Add("eb", 77.78f)
                .Add("e", 82.41f)
                .Add("f", 87.31f)
                .Add("f#", 92.5f)
                .Add("gb", 92.5f)
                .Add("g", 98.0f)
                .Add("g#", 103.83f)
                .Add("ab", 103.83f)
                .Add("a", 110.0f)
                .Add("a#", 116.54f)
                .Add("bb", 116.54f)
                .Add("b", 123.47f),

            new FloatDictionary(17,10)      // C3
                .Add("c", 130.81f)
                .Add("c#", 138.59f)
                .Add("db", 138.59f)
                .Add("d", 146.83f)
                .Add("d#", 155.56f)
                .Add("eb", 155.56f)
                .Add("e", 164.81f)
                .Add("f", 174.61f)
                .Add("f#", 185.0f)
                .Add("gb", 185.0f)
                .Add("g", 196.0f)
                .Add("g#", 207.65f)
                .Add("ab", 207.65f)
                .Add("a", 220.0f)
                .Add("a#", 233.08f)
                .Add("bb", 233.08f)
                .Add("b", 246.94f),
                
            new FloatDictionary(17,10)      // C4
                .Add("c", 261.63f)
                .Add("c#", 277.18f)
                .Add("db", 277.18f)
                .Add("d", 293.66f)
                .Add("d#", 311.13f)
                .Add("eb", 311.13f)
                .Add("e", 329.63f)
                .Add("f", 349.23f)
                .Add("f#", 369.99f)
                .Add("gb", 369.99f)
                .Add("g", 392.00f)
                .Add("g#", 415.30f)
                .Add("ab", 415.30f)
                .Add("a", 440.00f)
                .Add("a#", 466.16f)
                .Add("bb", 466.16f)
                .Add("b", 493.88f),

            new FloatDictionary(17,10)      // C5
                .Add("c", 523.25f)
                .Add("c#", 554.37f)
                .Add("db", 554.37f)
                .Add("d", 587.33f)
                .Add("d#", 622.25f)
                .Add("eb", 622.25f)
                .Add("e", 659.26f)
                .Add("f", 698.46f)
                .Add("f#", 739.99f)
                .Add("gb", 739.99f)
                .Add("g", 783.99f)
                .Add("g#", 830.61f)
                .Add("ab", 830.61f)
                .Add("a", 880.0f)
                .Add("a#", 932.33f)
                .Add("bb", 932.33f)
                .Add("b", 987.77f),

            new FloatDictionary(17,10)      // C6
                .Add("c", 1046.5f)
                .Add("c#", 1108.73f)
                .Add("db", 1108.73f)
                .Add("d", 1174.66f)
                .Add("d#", 1244.51f)
                .Add("eb", 1244.51f)
                .Add("e", 1318.51f)
                .Add("f", 1396.91f)
                .Add("f#", 1474.98f)
                .Add("gb", 1474.98f)
                .Add("g", 1567.98f)
                .Add("g#", 1661.22f)
                .Add("ab", 1661.22f)
                .Add("a", 1760.0f)
                .Add("a#", 1864.66f)
                .Add("bb", 1864.66f)
                .Add("b", 1975.53f),

            new FloatDictionary(17,10)      // C7
                .Add("c", 2093.0f)
                .Add("c#", 2217.46f)
                .Add("db", 2217.46f)
                .Add("d", 2349.32f)
                .Add("d#", 2849.02f)
                .Add("eb", 2849.02f)
                .Add("e", 2637.02f)
                .Add("f", 2793.83f)
                .Add("f#", 2959.96f)
                .Add("gb", 2959.96f)
                .Add("g", 3135.96f)
                .Add("g#", 3322.44f)
                .Add("ab", 3322.44f)
                .Add("a", 3520.0f)
                .Add("a#", 3729.31f)
                .Add("bb", 3729.31f)
                .Add("b", 3951.07f)
        };

    /// <summary>
    /// Static method to locate a note in the dictionaries defined above
    /// </summary>
    /// <param name="octave">Octave number (0-7)</param>
    /// <param name="note">Note to be found: eg. F#, A, Bb</param>
    /// <returns></returns>
    public static float GetFrequency(int octave, string note)
    {
        float frequency = 0.0f;

        if (octave >= 0 && octave <= 7)
        {
            if (Octaves[octave].ContainsKey(note.ToLower()))
            {
                frequency = (float)Octaves[octave].GetValue(note.ToLower());
            }
        }

        return frequency;
    }
}
