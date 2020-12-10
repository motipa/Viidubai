using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Vii.Helper;

namespace Vii.Views
{
    public partial class EventPage : ContentPage
    {
        string username = Settings.UserName;
        public EventPage()
        {
            InitializeComponent();
        }
       
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ReservationPage());
        }
        private void Listen_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://soundcloud.com/vii-marketing"));
          
        }
        protected override async void OnAppearing()
        {
            if (username != "")
            {
                base.OnAppearing();
                // imgName.Source = ImageSource.FromResource("tablebook2.jpg");
            }
            else
            {
                Application.Current.MainPage = new SignInPage();

            }
        }
    } 
}
  

   
