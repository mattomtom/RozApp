using System;
using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.Speech;
using RozApp.Droid.Services;
using RozApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

[assembly: Xamarin.Forms.Dependency(typeof(SpeechToTextService))]
namespace RozApp.Droid.Services
{
    public class SpeechToTextService : ISpeechToText
    {
        public SpeechToTextService()
        {
        }

        public event EventHandler<string> OnRecognize;


        public void StartReconigze()
        {
            Console.WriteLine("StartReconigze");
            string rec = Android.Content.PM.PackageManager.FeatureMicrophone;
            if (rec != "android.hardware.microphone")
            {
                var alert = new AlertDialog.Builder(Forms.Context);
                alert.SetTitle("You don't seem to have a microphone to record with");
                alert.SetPositiveButton("OK", (sender, e) =>
                {
                    return;
                });
                alert.Show();
            }

            var activity = (MainActivity)Forms.Context;
            var listener = new ActivityResultListener(activity, this);

            var voiceIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
            voiceIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
            voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 1500);
            voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 1500);
            voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 15000);
            voiceIntent.PutExtra(RecognizerIntent.ExtraMaxResults, 1);
            voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.Default);
            activity.StartActivityForResult(voiceIntent, 0);
        }

        private class ActivityResultListener
        {
            //private TaskCompletionSource<bool> Complete = new TaskCompletionSource<bool>();
            //public Task<bool> Task { get { return this.Complete.Task; } }

            MainActivity activity;
            SpeechToTextService parentService;
            public ActivityResultListener(MainActivity activity, SpeechToTextService parentService)
            {
                // subscribe to activity results
                this.activity = activity;
                this.activity.ActivityResult += OnActivityResult;
                this.parentService = parentService;
            }

            private void OnActivityResult(int requestCode, Result resultCode, Intent data)
            {
                // unsubscribe from activity results
                if (requestCode == 0)
                {
                    if (resultCode == Result.Ok)
                    {
                        activity.ActivityResult -= OnActivityResult;
                        var matches = data.GetStringArrayListExtra(RecognizerIntent.ExtraResults);

                        if (matches.Count != 0)
                        {
                            Console.WriteLine(matches[0]);
                            parentService.OnRecognize?.Invoke(parentService, matches[0]);
                            //string textInput = textBox.Text + matches[0];
                            //textBox.Text = textInput;
                            /*switch (matches[0].Substring(0, 5).ToLower())
                            {
                                case "north":
                                    //MovePlayer(0);
                                    break;
                                case "south":
                                    //MovePlayer(1);
                                    break;
                            }*/
                        }
                    }
                    else
                    {

                    }

                }
            }
        }
    }
}