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
    public partial class ForgetPasswordPage : ContentPage
    {
        private SignUpViewModel _signUp;
        public ForgetPasswordPage()
        {
            InitializeComponent();
            SignUpViewModel signUp = new SignUpViewModel();
            _signUp = signUp;
            BindingContext = _signUp;
        }
        async void sendlink_Button_Click(object sender, EventArgs e)
        {
            _signUp.userModel.Email = Email.Text;
            _signUp.SendCodeforActivation(Email.Text);
            await DisplayAlert("Success", "Password change link sent to your email", "OK");
            UpdatePanel.IsVisible = true;
        }
        async void changepassword_Button_Clicked(object sender, EventArgs e)
        {
            _signUp.userModel.ActivationCode = ActivationCode.Text;
            _signUp.userModel.Password = Password.Text;

            int s = _signUp.OnupdatePassword();
            if (s == 1)
            {
                await DisplayAlert("Success", "Your password has been changed successfully!", "OK");
                Application.Current.MainPage = new SignInPage();
            }
        }
    }
}