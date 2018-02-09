using System;
namespace RozApp.Services
{
    public interface ISpeechToText
    {
        event EventHandler<string> OnRecognize;
        void StartReconigze();
    }
}
