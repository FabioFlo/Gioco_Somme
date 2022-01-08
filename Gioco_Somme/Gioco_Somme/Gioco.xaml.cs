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
        private int countDown;
        private int countDownSecondsTot = 10;
        public int punteggio = 0;
        
        
       

        private void btn_Risp_A_Clicked(object sender, EventArgs e)
        {
            if (btn_Risp_A.Text == $"{result}")
            {
                Punteggio();
                StartQuiz();
                Reset();
            }
        } //tasto A

        private void btn_Risp_B_Clicked(object sender, EventArgs e)
        {
            if (btn_Risp_B.Text == $"{result}")
            {
                Punteggio();
                StartQuiz();
                Reset();
            }
        } //tasto B

        private void btn_Risp_C_Clicked(object sender, EventArgs e)
        {
            if (btn_Risp_C.Text == $"{result}")
            {
                Punteggio();
                StartQuiz();
                Reset();
            }
        } //tasto C

        private void btn_startGame_Clicked(object sender, EventArgs e) // inizia la partita
        {


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
            // per la gestione del countdown
            countDown = countDownSecondsTot;
            lbl_countDown.Text = "";
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {

                if (countDown > 0)
                {
                    countDown -= 1;
                    
                }
                Device.BeginInvokeOnMainThread(() =>
                {
                    lbl_countDown.Text = countDown.ToString();
                });
                return returnValue; // True = ripeti, False = Stop timer
            });

        }

        async private void btn_esci_Clicked(object sender, EventArgs e)// per uscire dal gioco
        {
            returnValue = false;
            await Navigation.PushAsync(new MainPage());
        }

        public void StartQuiz()
        {

            numA = numRandom.Next(1, 50);
            numB = numRandom.Next(1, 50);
            rispostaErrataA = numRandom.Next(2, 100);
            rispostaErrataB = numRandom.Next(2, 100);

            lbl_quiz.Text = $"{numA} + {numB} =";
            result = numA + numB;

            posizione = numRandom.Next(2); // per cambiare la posizione della risposta esatta
            if (posizione == 0) // la risposta corretta apparirà sul bottona A
            {
                btn_Risp_A.Text = $"{result}";
                btn_Risp_B.Text = $"{rispostaErrataA}";
                btn_Risp_C.Text = $"{rispostaErrataB}";


            }
            else if (posizione == 1) //la risposta coretta apparirà sul bottone B
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




        } // crea la domanda e le risposte
        public void Reset()
        {
            if (countDown != countDownSecondsTot)
            {
                countDown = countDownSecondsTot;
            }
        } // riporta count a 10 secondi
        public void Punteggio()
        {
            if (returnValue==true)
            {
                punteggio += countDown;
                lbl_punteggio.Text = punteggio.ToString();
            }
            
        } // assegnazione punteggio

    }


}
