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
	        await letturainiziale("CIAO MAURIZIO! Sono il tuo assistente vocale, inserisci la tua temperatura corporia dopo il segnale acustico");
            Device.StartTimer(TimeSpan.FromSeconds(7), () =>

            {
                InizioRiconoscimentoVocaleFebbre();
                return false;
	        });
          
        }

	    public async void InserimentoPressione()
	    {
	        await letturainiziale("Bene! Ora potresti darmi i dati della tua pressione sanguigna MAURIZIO? dopo il segnale acustico");
	        Device.StartTimer(TimeSpan.FromSeconds(10), () =>

	        {
	            InizioRiconoscimentoVocalePressione();
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
	        lblTemperatura.Text = txtResult.Text;
	        Device.StartTimer(TimeSpan.FromSeconds(4), () =>

	        {
	            InserimentoPressione();
                return false;
	        });

        }
        public async void InizioRiconoscimentoVocalePressione()
        {
            var result = await CrossSpeechToText.StartVoiceInput("Voice Input!");
            txtResult.Text = result;
            await lettura("hai inserito" + txtResult.Text);
            lblPressione.Text = txtResult.Text;

            Device.StartTimer(TimeSpan.FromSeconds(3), () =>

            {
                return false;
            });

        }

        private async void IniziaRiconoscimento(object sender, EventArgs e)
	    {
	        
	    }
    }
}
