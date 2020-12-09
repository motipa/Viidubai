using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vii.Helper;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vii.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : ContentPage
    {
        string username = Settings.UserName;
        public ContactPage()
        {//ghghg

            InitializeComponent();
        }

        private void FB_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(" https://m.facebook.com/ViiDubai/"));

        }

        private void Instagram_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.instagram.com/viidubai/?hl=en"));

        }
        private void Youtube_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.youtube.com/channel/UCudFTW-A72acizU5mIn1s5g?view_as=subscriber"));

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