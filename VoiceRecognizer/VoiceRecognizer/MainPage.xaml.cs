using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.CrossSpeechToText.Stt;
using Xamarin.Forms;

namespace VoiceRecognizer
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

	    private async void IniziaRiconoscimento(object sender, EventArgs e)
	    {
	      //  DependencyService.Get<ITextToSpeech>().Speak("INIZIO RICONOSCIMENTO VOCALE");

	        var result = await CrossSpeechToText.StartVoiceInput("Voice Input!");
	        txtResult.Text = result;
	    }
    }
}
