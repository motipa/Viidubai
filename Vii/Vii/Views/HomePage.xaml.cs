using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Timers;
using System.ComponentModel;
using Vii.Helper;

namespace Vii.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]
    public partial class HomePage : ContentPage
    {
        public string Heading { get; set; }
        public string Caption { get; set; }
        public ImageSource Pic { get; set; }
        string Username = Settings.UserName;
        public HomePage()
        {
            InitializeComponent();
            //Setup();
            DateTime objdate = DateTime.Today;
            string Day = DateTime.Now.DayOfWeek.ToString();

            if (Day == "Sunday")
            {
                // Heading = "SUNDAY";
                Caption = "Begin the week with some upbeat HipHop and RnB tunes by Khaleeji, DJ MadH, DJ Sam B and DJ MGK all night. ";
                Pic = "SUNDAY.jpg";

            }
            else if (Day == "Monday")
            {
                //Heading = "MONDAY";
                Caption = "Mondays, we’re taking you Uptown! Enjoy some fantastic hip hop and RnB tunes ";
                Pic = "MONDAY.jpg";
            }
            else if (Day == "Tuesday")
            {
                // Heading = "TUESDAY";
                Caption = "Viva la fiesta, viva la noche! It’s Chicas Night every Tuesday, ladies! ";
                Pic = "TUESDAY.jpg";
            }
            else if (Day == "Wednesday")
            {
                // Heading = "WEDNESDAY";
                Caption = "Old school tunes are here to beat your weekday blues – Soul Juice ";
                Pic = "WEDNESDAY.jpg";
            }
            else if (Day == "Friday")
            {
                // Heading = "FRIDAY";
                Caption = "Step up your weekend game with the Red Madness brunch on Friday. ";
                Pic = "FRIDAY.jpg";
            }
            else if (Day == "Thursday")
            {
                // Heading = "THURSDAY";
                Caption = "Begin your weekend with the Takeover Brunch on Thursday. ";
                Pic = "FRIDAY.jpg";
            }

            else
            {
                // Heading = "SATURDAY";
                Caption = "Yala Habibi! Venture into a Maylay Garden themed experience at the Secret Garden. ";
                Pic = "SATURDAY1.jpg";
            }

            this.BindingContext = this;

        }

        private async void Caption_Tapped(object sender, EventArgs e)
        {
            if (Username != "")
            {
                await Navigation.PushAsync(new Vii.Views.EventPage());
            }

        }

        private async void SecretGarden_Tapped(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new Vii.Views.AboutPage());
            var MyAppsFirstPage = new HomePage();
            Application.Current.MainPage = new NavigationPage(MyAppsFirstPage);
            await Application.Current.MainPage.Navigation.PopAsync(); //Remove the page currently on top.
            await Application.Current.MainPage.Navigation.PushAsync(new AboutPage());
        }

        private async void RedRoom_Tapped(object sender, EventArgs e)
        {
            var MyAppsFirstPage = new HomePage();
            Application.Current.MainPage = new NavigationPage(MyAppsFirstPage);
            await Application.Current.MainPage.Navigation.PopAsync(); //Remove the page currently on top.
            await Application.Current.MainPage.Navigation.PushAsync(new AboutPage());

        }
        private async void AmberHall_Tapped(object sender, EventArgs e)
        {
            var MyAppsFirstPage = new HomePage();
            Application.Current.MainPage = new NavigationPage(MyAppsFirstPage);
            await Application.Current.MainPage.Navigation.PopAsync(); //Remove the page currently on top.
            await Application.Current.MainPage.Navigation.PushAsync(new AboutPage());
        }
        
    }
}

