using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

//Next is a little class that defines a Note. Now a note is really just a frequency, but we can create it using a letter such as F or C# or Bb.

public class Note
{
    private int _octave;
    private string _noteLetter;
    private float _frequency;
    private int _duration;

    public Note(float frequency, int duration)
    {
        _noteLetter = "";
        _octave = 4;
        _frequency = frequency;
        _duration = duration;
    }

    public Note(int octave, string note, int duration)
    {
        SetFrequency(octave, note);

        _duration = duration;
    }

    /// <summary>
    /// Sets the note based on a text note eg. F#
    /// and the octave number.
    /// </summary>
    /// <param name="octave">Octave note is to be played from (0-7)</param>
    /// <param name="note">String note. eg. C or F# or Bb</param>
    private void SetFrequency(int octave, string note)
    {
        // get the frequency
        float frequency = NoteFrequencies.CalculateFrequency(octave, note);

        // if the note was valid
        if (frequency != 0.0f)
        {
            _frequency = frequency;
            _octave = octave;
            _noteLetter = note;
        }
        else // otherwise default to middle C
        {
            _frequency = NoteFrequencies.CalculateFrequency(4, "c");
            _octave = 4;
            _noteLetter = "c";
        }
    }

    public void Play(PiezoSpeaker speaker)
    {
        speaker.Play(_frequency, _duration);
    }

    public string NoteLetter
    {
        get { return _noteLetter; }
        set
        {
            SetFrequency(_octave, value);
        }
    }

    public int Octave
    {
        get { return _octave; }
        set
        {
            _octave = value;


        }
    }

    public float Frequency
    {
        get { return _frequency; }
    }

    public int Duration
    {
        get { return _duration; }
        set { _duration = value; }
    }
}
