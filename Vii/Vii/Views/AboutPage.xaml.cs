using System;
using System.ComponentModel;
using Vii.Helper;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vii.Views
{
    public partial class AboutPage : ContentPage
    {
        string username = Settings.UserName;
        public AboutPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
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