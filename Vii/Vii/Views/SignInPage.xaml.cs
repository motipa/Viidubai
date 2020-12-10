using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vii.ViewModels;
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
            LoginViewModel log = new LoginViewModel(this);
            this.BindingContext = log;
        }
        private async void menu_Button_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new Vii.Views.FoodMenuPage());
        }

        private async void signup_Button_Clicked(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new SignUp();
            await Navigation.PushAsync(new Vii.Views.SignUp());
        }       
        private async void privacypolicy_tapped(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new PrivacyPolicyPage());
            await Navigation.PushAsync(new Vii.Views.PrivacyPolicyPage());
        }
        private async void link_button(object sender, EventArgs e)
        {
            // await Navigation.PushAsync(new ForgetPasswordPage());
            await Navigation.PushAsync(new Vii.Views.ForgetPasswordPage());

        }
    }
}