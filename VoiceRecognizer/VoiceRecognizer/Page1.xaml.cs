using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoiceRecognizer.SpeechRecognition;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VoiceRecognizer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
        public delegate ContentPage GetEditorInstance(string InitialEditorText);
        static public GetEditorInstance EditorFactory;
        static ISpeechToText speechRecognitionInstnace;
         public Page1()
         {
            InitializeComponent();
             if (Device.RuntimePlatform == Device.Android)
             {
                androidLayout.IsVisible = true;
                 voiceButton.OnTextChanged += (s) => {
                     textLabelDroid.Text = s;
                 };
            }
             else
             {
                iOSLayout.IsVisible = true;
                 this.Content = iOSLayout;
                 speechRecognitionInstnace = DependencyService.Get<ISpeechToText>();
                 speechRecognitionInstnace.textChanged += OnTextChange;
             }
			


        }

        public void OnStart(Object sender, EventArgs args)
        {
            speechRecognitionInstnace.Start();
            nameButtonStart.IsEnabled = false;
            nameButtonStop.IsEnabled = true;
        }
        public void OnStop(Object sender, EventArgs args)
        {
            speechRecognitionInstnace.Stop();
            nameButtonStart.IsEnabled = true;
            nameButtonStop.IsEnabled = false;

        }
        public void OnTextChange(object sender, EventArgsVoiceRecognition e)
        {
            textLabeliOS.Text = e.Text;
            if (e.IsFinal)
            {
                nameButtonStart.IsEnabled = true;
            }
        }
    }
}
