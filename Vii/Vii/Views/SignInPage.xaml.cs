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
        private LoginViewModel _log;
        public SignInPage()
        {
            InitializeComponent();
            LoginViewModel log = new LoginViewModel();
            _log = log;
            BindingContext = _log;
        }
        private async void menu_Button_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new Vii.Views.FoodMenuPage());
        }

        private async void signup_Button_Clicked(object sender, EventArgs e)
        {
           // Application.Current.MainPage = new SignUp();
           //await Application.Current.MainPage.Navigation.PushAsync(new SignInPage());
           // await Application.Current.MainPage.Navigation.PopAsync();
            //await Navigation.PushAsync(new Vii.Views.SignUp());

            var MyAppsFirstPage = new SignInPage();
            Application.Current.MainPage = new NavigationPage(MyAppsFirstPage);
            await Application.Current.MainPage.Navigation.PopAsync();
            await Application.Current.MainPage.Navigation.PushAsync(new SignUp());
        }       
        private async void privacypolicy_tapped(object sender, EventArgs e)
        {
            var MyAppsFirstPage = new SignInPage();
            Application.Current.MainPage = new NavigationPage(MyAppsFirstPage);
            await Application.Current.MainPage.Navigation.PopAsync();
            await Application.Current.MainPage.Navigation.PushAsync(new PrivacyPolicyPage());
        }
        private async void link_button(object sender, EventArgs e)
        {
            var MyAppsFirstPage = new SignInPage();
             Application.Current.MainPage = new NavigationPage(MyAppsFirstPage);
            await Application.Current.MainPage.Navigation.PopAsync(); //Remove the page currently on top.
            await Application.Current.MainPage.Navigation.PushAsync(new ForgetPasswordPage());
           
        }        

        private void Password_OnChange(object sender, TextChangedEventArgs e)
        {
            Entry s = (Entry)sender;

            if (!string.IsNullOrEmpty(s.Text))
            {
                LabelPassword.IsVisible = true;
                LabelPassword.Text = s.Placeholder.ToString();
            }
            else
            {
                LabelPassword.IsVisible = false;
            }
        }

        private void OnTextEmail(object sender, TextChangedEventArgs e)
        {
            Entry s = (Entry)sender;

            if (!string.IsNullOrEmpty(s.Text))
            {
                LabelTitle.IsVisible = true;
                LabelTitle.Text = s.Placeholder.ToString();
            }
            else
            {
                LabelTitle.IsVisible = false;
            }
        }

        private async void SignIn_Check(object sender, EventArgs e)
        {
            bool ok =await _log.LoginCheck();
            if(ok)
            {
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                lblError.Text = "Invalid User";
            }
        }
    }
}