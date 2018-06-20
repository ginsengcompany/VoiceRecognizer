using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.CrossSpeechToText.Stt;
using VoiceRecognizer.Dependency;
using Xamarin.Forms;

namespace VoiceRecognizer
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            IngressoPagina();
        }

	    public async void IngressoPagina()
	    {
	        await letturainiziale("Inserisci il valore della temperatura corporea del paziente in gradi celsius dopo il segnale acustico");
            Device.StartTimer(TimeSpan.FromSeconds(7), () =>

            {
                InizioRiconoscimentoVocaleFebbre();
                return false;
	        });
          
        }

	    public async void InserimentoPressione()
	    {
	        await letturainiziale("Inserisci il valore della pressione sanguigna del paziente dopo il segnale acustico");
	        Device.StartTimer(TimeSpan.FromSeconds(7), () =>

	        {
	            InizioRiconoscimentoVocaleFebbre();
	            return false;
	        });
        }

	    public async Task lettura(string valore)
	    {
	        DependencyService.Get<ITextToSpeech>().Speak(valore);

        }
	    public async Task letturainiziale(string valorePronuncia)
	    {
	        DependencyService.Get<ITextToSpeech>().Speak(valorePronuncia);

	    }

        public async void InizioRiconoscimentoVocaleFebbre()
	    {
	        var result = await CrossSpeechToText.StartVoiceInput("Voice Input!");
	        txtResult.Text = result;
	        await lettura("hai inserito" + txtResult.Text);
	        Device.StartTimer(TimeSpan.FromSeconds(3), () =>

	        {
	            InserimentoPressione();
                return false;
	        });

        }

        private async void IniziaRiconoscimento(object sender, EventArgs e)
	    {
	        
	    }
    }
}
