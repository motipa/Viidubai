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
        private void menu_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FoodMenuPage());
        }

        private void signup_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUp());
        }       
        private void privacypolicy_tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PrivacyPolicyPage());
        }
        private void link_button(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgetPasswordPage());
        }
    }
}