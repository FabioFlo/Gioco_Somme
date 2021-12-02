using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gioco_Somme
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Gioco : INotifyPropertyChanged
    {
        public Gioco()
        {
            InitializeComponent();

        }

        Random numRandom = new Random(); // randomizzando i fattori, la risposta varia automaticamente
        int numA, numB;
        int rispostaErrataA, rispostaErrataB;
        int posizione; // per far variare la posizione della risposta esatta sui bottoni
        private object result;
        private bool returnValue;
        
        private void btn_Risp_A_Clicked(object sender, EventArgs e)
        {
            if (btn_Risp_A.Text == $"{result}")
            {
                StartQuiz();


            }
        }

        private void btn_Risp_B_Clicked(object sender, EventArgs e)
        {
            if (btn_Risp_B.Text == $"{result}")
            {

                StartQuiz();

            }
        }

        private void btn_Risp_C_Clicked(object sender, EventArgs e)
        {
            if (btn_Risp_C.Text == $"{result}")
            {
                StartQuiz();
            }
        }

        private void btn_startGame_Clicked(object sender, EventArgs e)
        {
            // per la gestione del countdown
 
            if (btn_startGame.Text == "Start")
            {
                StartQuiz();
                returnValue = true;
                btn_startGame.Text = "Stop";
            }
            else
            {
                btn_startGame.Text = "Start";
                returnValue = false;
            }
            int count = 10;
            lbl_seconds.Text = "";
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                
                // Do something

                if (count > 0)
                {
                    count -= 1;
                }
                Device.BeginInvokeOnMainThread(() =>
                {
                    lbl_seconds.Text = count.ToString();
                });
                return returnValue; // True = Repeat again, False = Stop the timer
            });

        }

        async private void btn_esci_Clicked(object sender, EventArgs e)
        {
            returnValue = false;
            await Navigation.PushAsync(new MainPage());
            // per uscire dal gioco

        }

        public void StartQuiz()
        {

            numA = numRandom.Next(1, 10);
            numB = numRandom.Next(1, 10);
            rispostaErrataA = numRandom.Next(2, 18);
            rispostaErrataB = numRandom.Next(2, 18);

            lbl_quiz.Text = $"{numA} + {numB} =";
            result = numA + numB;

            posizione = numRandom.Next(2); // per cambiare la posizione della risposta esatta
            if (posizione == 0) // la risposta apparirà sul bottona A
            {
                btn_Risp_A.Text = $"{result}";
                btn_Risp_B.Text = $"{rispostaErrataA}";
                btn_Risp_C.Text = $"{rispostaErrataB}";


            }
            else if (posizione == 1) //la risposta pparirà sul bottone B
            {
                btn_Risp_B.Text = $"{result}";
                btn_Risp_A.Text = $"{rispostaErrataA}";
                btn_Risp_C.Text = $"{rispostaErrataB}";
            }
            else // oppure su C
            {
                btn_Risp_C.Text = $"{result}";
                btn_Risp_A.Text = $"{rispostaErrataA}";
                btn_Risp_B.Text = $"{rispostaErrataB}";
            }




        }

    }


}
