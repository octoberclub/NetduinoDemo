using System;
using Microsoft.SPOT;

public static class NoteFrequencies
{
    /// <summary>
    /// Static method to calculate the frequency of a note from its name and octave.
    /// </summary>
    /// <param name="octave">Octave number (0-7)</param>
    /// <param name="note">Note to be found: eg. F#, A, Bb</param>
    /// <returns></returns>
    public static float CalculateFrequency(int octave, string note)
    {
        string noteLC = note.ToLower();
        string[] notes = "c,c#,d,d#,e,f,f#,g,g#,a,a#,b".Split(',');

        // loop through each note until we find the index of the one we want        
        for (int n = 0; n < notes.Length; n++)
        {
            if (notes[n] == noteLC // frequency found for major and sharp notes
                || (note.Length > 1 && noteLC[1] == 'b' && notes[n + 1][0] == noteLC[0])) // or flat of next note
            {
                // Multiply initial note by 2 to the power (n / 12) to get correct frequency, 
                //  (where n is the number of notes above the first note). 
                //  Then mutiply that value by 2 to go up each octave
                return (float)(16.35 * System.Math.Pow(2, n / 12f) * System.Math.Pow(2, octave));
            }
        }
        throw new ArgumentException("No frequency found for note : " + note, note);
    }
}
