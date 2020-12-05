using System;
using System.Collections.Generic;
using Vii.Helper;
using Vii.ViewModels;
using Vii.Views;
using Xamarin.Forms;

namespace Vii
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            Settings.UserName = null;
            // await Shell.Current.GoToAsync("//LoginPage");
            Application.Current.MainPage = new SignInPage();
           
           // Application.Current.MainPage = new HomePage();


        }
        //private async void OnMenuItemClicked1(object sender, EventArgs e)
        //{
         
        //   // Application.Current.MainPage = new HomePage();


        //}
    }
}
