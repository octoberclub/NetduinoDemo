using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Netduino.PiezoTest
{
    /// <summary>
    /// Program based on Ray Mckaig 's forum post 'Music with Piezo speaker' on Netduino website 13 Dec 2010
    /// http://forums.netduino.com/index.php?/topic/831-music-with-a-piezo-speaker/page__p__6044__hl__piezo__fromsearch__1#entry6044
    /// 
    /// Video tutorial here:
    /// http://www.youtube.com/watch?v=vEr4qk9lTEU
    /// 
    /// I've tried to put this together implementing some of the missing classes from the post.
    /// 
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            // write your code here
            Test_PiezoSpeaker();
        }

        //And finally, some test code that demonstrates using the above code to play music.

        public static void Test_PiezoSpeaker()
        {
            // setup the speaker on digital pin 5
            PiezoSpeaker speaker = new PiezoSpeaker(Pins.GPIO_PIN_D5);

            // define some tunes
            string[] tunes = new string[] 
            {
                "C * F / F * F A G / F * G A F / F A + C D" , // Auld Lang Syne
                "D / D * * E D G * F# / / D / D * * E D A * G / / D / D * * + D - B G F# * E / / + C / C * * - B G A * G", // Happy birthday
                "C C G G A A * G / F F E E D D * C / G G F F E E * D / G G F F E E * D / C C G G A A * G / F F E E D D * C" , // twinkle, twinkle
                "A B + C D E F# G# A G F E D C - B A", // melodic minor scale                
            };


            // each time the button is pressed we're going to cycle to the next tune in the list
            // if we reach the end of the list, start at the beginning again.

            int which = -1;

            Button button = new Button(Pins.ONBOARD_SW1);
            button.Pressed += delegate
            {
                which++;

                if (which == tunes.Length)
                    which = 0;

                speaker.Play(tunes[which], 4, 333);
            };

            // as this is driven by the button being pressed, we don't need to poll
            // anything so we just put the main thread to sleep and wait... and wait... and wait...

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
