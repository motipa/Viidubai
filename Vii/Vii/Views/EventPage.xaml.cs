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

namespace Vii.Views
{
    public partial class EventPage : ContentPage
    {
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
    } 
}
  

   
