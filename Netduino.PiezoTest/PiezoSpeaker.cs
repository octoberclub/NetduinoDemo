using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

//This next class defines how we interface with the Piezo speaker.

//    using SecretLabs.NETMF.Hardware;
//    using System.Threading;

public class PiezoSpeaker
{
    private PWM _pin;

    // if the _busy flag is true we will just
    // ignore any request to make noise.
    private bool _busy = false;

    public PiezoSpeaker(Cpu.Pin pin)
    {
        _pin = new PWM(pin);

        // take the pin low, so the speaker
        // doesn't make any noise until we
        // ask it to
        _pin.SetDutyCycle(0);
    }

    /// <summary>
    /// Play a particular frequency for a defined
    /// time period
    /// </summary>
    /// <param name="frequency">The frequency (in hertz) of the note to be played</param>
    /// <param name="duration">How long (in milliseconds: 1000 = 1 second) the note is to play for</param>
    public void Play(float frequency, int duration)
    {
        if (!_busy)
        {
            _busy = true;

            // calculate the actual period and turn the
            // speaker on for the defined period of time
            uint period = (uint)(1000000 / frequency);
            _pin.SetPulse(period, period / 2);

            Thread.Sleep(duration);

            // turn the speaker off
            _pin.SetDutyCycle(0);
            _busy = false;
        }
    }

    /// <summary>
    /// Play an array of Notes
    /// </summary>
    /// <param name="notes">An array of Note objects, each defining a frequency and duration</param>
    public void Play(Note[] notes)
    {
        foreach (Note note in notes)
        {
            Play(note.Frequency, note.Duration);
        }
    }

    /// <summary>
    /// Play a sequence of notes using standard letters C, D, E F#, etc. There
    /// are 7 octaves defined and the following instructions allow the whole
    /// range of notes to be accessed.
    /// 
    /// Notes: C, C#, Db, D, D#, Eb, E, F, F#, Gb, G, G#, Ab, A, A#, Bb, B
    /// Next note will be from the octave above: +
    /// Next note will be from the octave below: -
    /// Double length of next note: *
    /// Halve length of the next note: /
    /// 
    /// Example: Auld Lang Syne
    /// C * F / F * F A G / F * G A F / F A + C D
    /// 
    /// TODO
    /// Would be useful to provide a means of defining the tempo of the next note
    /// rather than the simplistic double and half.
    /// 
    /// Maybe use numbers to define the length of notes
    /// 1/4, 1/8, 1/16, 2/3, etc.
    /// </summary>
    /// <param name="sequence">A string of notes speperated by a space</param>
    /// <param name="initialOctave">The number of the default octave (4 = middle C), Allowed values: 0-7</param>
    /// <param name="initialTempo">The length of the first note specified in milliseconds</param>
    public void Play(string sequence, int initialOctave, int initialTempo)
    {
        string[] notes = sequence.Split(' ');

        // initialise the Note object we'll reuse for playing each note
        Note note = new Note(initialOctave, "c", initialTempo);

        foreach (string item in notes)
        {
            if (item != "")
            {
                if (item == "*") // double the current tempo
                {
                    note.Duration *= 2;
                }
                else if (item == "/") // halve the current tempo
                {
                    note.Duration /= 2;
                }
                else if (item == "-") // move to the octave below
                {
                    if (note.Octave > 0)
                        note.Octave--;
                }
                else if (item == "+") // move to the octave above
                {
                    if (note.Octave < 8)
                        note.Octave++;
                }
                else
                {
                    note.NoteLetter = item;
                    Play(note.Frequency, note.Duration);

                    // small gap between notes
                    Thread.Sleep(10);
                }
            }
        }
    }
}
