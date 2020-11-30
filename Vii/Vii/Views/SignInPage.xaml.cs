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
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            InitializeComponent();
        }
        private void menu_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FoodMenuPage());
        }

        private void signup_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUp());
        }
        private void forgotPassword_tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgetPasswordPage());
        }
        private void privacypolicy_tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PrivacyPolicyPage());
        }

        async void signinsubmit_Button_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Success", "Sign In successfull", "OK");
        }
    }
}