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
        
		public MainPage(string username)
		{
			InitializeComponent();
		    this.username = username;
            lbltitolo.Text = " DATI DI " + username + " ";
            lbltitolo.Text = lbltitolo.Text.ToUpperInvariant();
            temperatura = "CIAO" + username + " Sono il tuo assistente vocale, inserisci la tua temperatura corporea dopo il segnale acustico";
            pressione = "Bene! Ora potresti darmi i dati della tua pressione sanguigna " + username + " dopo il segnale acustico";
            battiti = "Bene! mi mancano solo i dati relativi ai tuoi battiti " + username + " potresti darmeli dopo il segnale acustico";
            IngressoPagina(lblTemperatura, temperatura);
        }

	    public async void IngressoPagina(Entry label,String stringa)
	    {
            string temp;

            await lettura(stringa);
            if (temperatura == stringa)
                temp = "temperatura";
            else if (pressione == stringa)
                temp = "pressione";
            else
                temp = "battiti";
            Device.StartTimer(TimeSpan.FromSeconds(7), () =>
            {
                InizioRiconoscimentoVocale(label, temp);
                return false;
	        });
            
        }

        public async void InizioRiconoscimentoVocale(Entry label,string stringa)
        {
            var result = await CrossSpeechToText.StartVoiceInput("Voice Input!");
            txtResult.Text = result;
            await lettura("hai inserito" + txtResult.Text);
            label.Text = txtResult.Text;

            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                if (stringa == "temperatura")
                    IngressoPagina(lblPressione, pressione);
                else if(stringa=="pressione")
                    IngressoPagina(lblBattito, battiti);

                return false;
            });
        }

        public async Task lettura(string valore)
	    {
	        DependencyService.Get<ITextToSpeech>().Speak(valore);

        }
    }
}
