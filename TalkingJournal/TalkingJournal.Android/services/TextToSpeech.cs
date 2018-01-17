

using Android.Speech.Tts;
using TalkingJournal.Droid.services;
using TalkingJournal.services;
using Xamarin.Forms;

[assembly: Dependency(typeof(TextToSpeechImpl))]
namespace TalkingJournal.Droid.services
{
    public class TextToSpeechImpl : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        private TextToSpeech _speaker;
        private string _toSpeak;

        public void Speak(string text)
        {
            _toSpeak = text;
            if (_speaker == null)
            {
                if (Android.App.Application.Context != null) 
                    _speaker = new TextToSpeech(Android.App.Application.Context, this);
            }
            else
            {
                _speaker.Speak(_toSpeak, QueueMode.Flush, null, null);
            }
        }

        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                _speaker.Speak(_toSpeak, QueueMode.Flush, null, null);
            }
        }
    }
}