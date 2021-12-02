using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Gioco_Somme
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }


        async private void btn_gioco_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new Gioco());
    }
}
