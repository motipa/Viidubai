using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vii.Services;
using Vii.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vii.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp : ContentPage
    {
        private SignUpViewModel _signUp;
        private ISignUp _isignup;

        public SignUp()
        {
            InitializeComponent();
            SignUpViewModel signUp = new SignUpViewModel();
            _signUp = signUp;
            BindingContext = _signUp;
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
        async void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            string theBase = password.Text;
            string confirmation = e.NewTextValue;
            // here is the change
           bool IsValid = (bool)theBase?.Equals(confirmation);

            ((Entry)sender).TextColor = IsValid ? Color.White : Color.Red;
        }
        async void Createaccount_Button_Clicked(object sender, EventArgs e)
        {
            if (password.Text == Confirmpassword.Text)
            {
                _signUp.userModel.FirstName = firstName.Text;
                _signUp.userModel.LastName = lastName.Text;
                _signUp.userModel.Email = email.Text;
                _signUp.userModel.Password = password.Text;
                _signUp.userModel.PhoneNumber = phone.Text;
                int s = _signUp.OnRegister();
                if (s == 1)
                {
                    await DisplayAlert("Registration", "Successfull", "OK");
                    await Navigation.PushAsync(new SignInPage());
                }
            }
            else
            {
               await DisplayAlert("Password", "Password Missmatch", "Ok");
            }
        }
    }
}