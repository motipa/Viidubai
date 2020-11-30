using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vii.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }
        private void privacypolicy_tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PrivacyPolicyPage());
        }
        private void signin_tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignInPage());
        }
        async void Createaccount_Button_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Success", "You have created an account successfully.Please login with Username and password", "OK");
        }
    }
}