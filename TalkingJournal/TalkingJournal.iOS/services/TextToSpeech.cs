using AVFoundation;
using TalkingJournal.iOS.services;
using TalkingJournal.services;
using Xamarin.Forms;

[assembly: Dependency(typeof(TextToSpeechImpl))]

namespace TalkingJournal.iOS.services
{
    public class TextToSpeechImpl : ITextToSpeech
    {
        public TextToSpeechImpl()
        {
            //
        }

        public void Speak(string text)
        {
            var speechSynthesizer = new AVSpeechSynthesizer();
            var speechUtterance = new AVSpeechUtterance(text)
            {
                Rate = AVSpeechUtterance.MaximumSpeechRate / 4,
                Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
                Volume = 0.5f,
                PitchMultiplier = 1.0f
            };

            speechSynthesizer.SpeakUtterance(speechUtterance);
        }
    }
}