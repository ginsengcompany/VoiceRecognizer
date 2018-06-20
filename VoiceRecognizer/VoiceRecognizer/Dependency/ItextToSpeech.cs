using System;

namespace VoiceRecognizer.Dependency
{
    public interface ITextToSpeech
    {
        void Speak(string text);
    }
}
