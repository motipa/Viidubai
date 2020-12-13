using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private async void privacypolicy_tapped(object sender, EventArgs e)
        {
            //PageprivacyPolicy.IsVisible = true;
            //SignUpView.IsVisible = false;
            //Navigation.PushAsync(new Vii.Views.PrivacyPolicyPage());
            var MyAppsFirstPage = new SignUp();
            Application.Current.MainPage = new NavigationPage(MyAppsFirstPage);
            await Application.Current.MainPage.Navigation.PopAsync(); //Remove the page currently on top.
            await Application.Current.MainPage.Navigation.PushAsync(new PrivacyPolicyPage());

        }
        private  void signin_tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage=new NavigationPage(new SignInPage());            
        }
        async void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            Entry s = (Entry)sender;

            if (!string.IsNullOrEmpty(s.Text))
            {
                lblConfirm.IsVisible = true;
                lblConfirm.Text = s.Placeholder.ToString();
            }
            else
            {
                lblConfirm.IsVisible = false;
            }
            string theBase = password.Text;
            string confirmation = e.NewTextValue;
            // here is the change
           bool IsValid = (bool)theBase?.Equals(confirmation);

            ((Entry)sender).TextColor = IsValid ? Color.White : Color.Red;
            if (IsValid)
            {
                btnSignup.IsEnabled = true;
            }
        }
        public bool IsPhoneNumber(string number)
        {
            int r;
            // return Regex.Match(n, @"^(\+[0-9])$").Success;
            bool isValid = int.TryParse(number, out r);
            return isValid;
        }
        async void Createaccount_Button_Clicked(object sender, EventArgs e)
        {
            
            if (Regex.Match(email.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
            {
                if (IsPhoneNumber(phone.Text))
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
                            Application.Current.MainPage = new SignInPage();
                        }
                    }
                    else
                    {   
                        await DisplayAlert("Password", "Password Mismatch", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Phone", "Invalid Phone", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Email", "Invalid Email", "Ok");
            }
        }

        private void fnamChange(object sender, TextChangedEventArgs e)
        {
            Entry s = (Entry)sender;

            if (!string.IsNullOrEmpty(s.Text))
            {
                LabelFname.IsVisible = true;
                LabelFname.Text = s.Placeholder.ToString();
            }
            else
            {
                LabelFname.IsVisible = false;
            }
        }

        private void lnamChange(object sender, TextChangedEventArgs e)
        {
            Entry s = (Entry)sender;

            if (!string.IsNullOrEmpty(s.Text))
            {
                LabelLname.IsVisible = true;
                LabelLname.Text = s.Placeholder.ToString();
            }
            else
            {
                LabelLname.IsVisible = false;
            }
        }

        private void phoneChange(object sender, TextChangedEventArgs e)
        {
            Entry s = (Entry)sender;

            if (!string.IsNullOrEmpty(s.Text))
            {
                lblphone.IsVisible = true;
                lblphone.Text = s.Placeholder.ToString();
            }
            else
            {
                lblphone.IsVisible = false;
            }
        }

        private void emailChange(object sender, TextChangedEventArgs e)
        {
            Entry s = (Entry)sender;

            if (!string.IsNullOrEmpty(s.Text))
            {
                lblemail.IsVisible = true;
                lblemail.Text = s.Placeholder.ToString();
            }
            else
            {
                lblemail.IsVisible = false;
            }
        }

        private void passchanged(object sender, TextChangedEventArgs e)
        {
            Entry s = (Entry)sender;

            if (!string.IsNullOrEmpty(s.Text))
            {
                lblpassword.IsVisible = true;
                lblpassword.Text = s.Placeholder.ToString();
            }
            else
            {
                lblpassword.IsVisible = false;
            }
        }
    }
}