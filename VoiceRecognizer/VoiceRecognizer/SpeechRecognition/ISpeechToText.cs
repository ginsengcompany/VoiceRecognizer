using System;
using System.Collections.Generic;
using System.Text;

namespace VoiceRecognizer.SpeechRecognition
{
    public interface ISpeechToText
    {
        void Start();
        void Stop();
        event EventHandler<EventArgsVoiceRecognition> textChanged;
    }
}
