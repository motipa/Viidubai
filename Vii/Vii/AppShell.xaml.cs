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
        }
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            Settings.UserName = null;           
            Application.Current.MainPage = new SignInPage();
        }        
    }
}
