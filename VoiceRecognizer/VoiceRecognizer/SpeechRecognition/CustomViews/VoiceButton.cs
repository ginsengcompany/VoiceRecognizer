using System;
using Xamarin.Forms;

namespace VoiceRecognizer.SpeechRecognition.CustomViews
{
    public class VoiceButton : Button
    {
        public Action<string> OnTextChanged { get; set; }
    }

}