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
        private string username;
        private string temperatura;
        private string pressione;
        private string battiti;
        private bool flag = false;
        
		public MainPage(string username)
		{
			InitializeComponent();
		    this.username = username;
            temperatura = "CIAO" + username + " Sono il tuo assistente vocale, inserisci la tua temperatura corporea dopo il segnale acustico";
            pressione = "Bene! Ora potresti darmi i dati della tua pressione sanguigna " + username + " dopo il segnale acustico";
            battiti = "Bene! mi mancano solo i dati relativi ai tuoi battiti " + username + " potresti darmeli dopo il segnale acustico";
            IngressoPagina();
        }

	    public async void IngressoPagina()
	    {

	        await lettura(temperatura);
            Device.StartTimer(TimeSpan.FromSeconds(7), () =>
            {
                while(!flag)
                    InizioRiconoscimentoVocale(lblTemperatura);
                return false;
	        });
            flag = false;
            await lettura(pressione);
            Device.StartTimer(TimeSpan.FromSeconds(7), () =>
            {
                while (!flag)
                    InizioRiconoscimentoVocale(lblPressione);
                return false;
            });
            flag = false;
            await lettura(battiti);
            Device.StartTimer(TimeSpan.FromSeconds(7), () =>
            {
                while (!flag)
                    InizioRiconoscimentoVocale(lblBattito);
                return false;
            });
        }

        public async void InizioRiconoscimentoVocale(Label label)
        {
            var result = await CrossSpeechToText.StartVoiceInput("Voice Input!");
            txtResult.Text = result;
            await lettura("hai inserito" + txtResult.Text);
            label.Text = txtResult.Text;

            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                flag = true;
                return false;
            });
        }

        public async Task lettura(string valore)
	    {
	        DependencyService.Get<ITextToSpeech>().Speak(valore);

        }
    }
}
