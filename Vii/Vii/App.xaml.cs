using System;
using Vii.Services;
using Vii.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vii
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Notification notification = new Notification();
            notification.callrefresh();
            MainPage = new AppShell();
        }
        protected override void OnStart()
        {
        }
        protected override void OnSleep()
        {
            Notification notification = new Notification();
            notification.callrefresh();
        }
        protected override void OnResume()
        {
        }
    }
}
