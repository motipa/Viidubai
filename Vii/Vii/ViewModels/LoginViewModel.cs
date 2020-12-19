using ClubApp.Models.Auth;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Vii.Helper;
using Vii.Models;
using Vii.Services;
using Vii.Views;
using Xamarin.Forms;

namespace Vii.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private Page _page;
        public LoginModel LoginModel { get; set; } = new LoginModel();
        public LoginService _apiServices;
        public LoginViewModel()
        {

        }
        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
        private string _error;
        public string ErrorMessage
        {
            get => _error;
            set { _error = value; }
        }
        public async Task<bool> LoginCheck()
        {
            try
            {
                _apiServices = new LoginService();
                AuthorizationModel authorization = new AuthorizationModel();
                authorization.Login = LoginModel.Username;
                authorization.Password = LoginModel.Password;
                authorization.AuthorizationType = "credentials";
                authorization.Client = "app";
                authorization.ClientSecret = "123";
                authorization.RefreshToken = "string";
                authorization.ApplicationId = new Guid();
                authorization.TenantId = new Guid();
                authorization.ListenerServiceName = "string";
                authorization.IntegrationPartnerName = "string";
                authorization.IntegrationPartnerSecret = "string";
               
                if (LoginModel.Username != null && LoginModel.Password != null)
                {
                    IsBusy = true;                   
                    var res = await _apiServices.LoginAsync(authorization);
                    if (res.AccessToken != null)
                    {
                        Settings.UserName = LoginModel.Username;
                        Settings.AccessToken = res.AccessToken;
                        Settings.RefreshToken = res.RefreshToken;
                        var datenow = DateTime.UtcNow;
                        Settings.AccessTokenExpirationDate = DateTime.UtcNow.AddMinutes(8);
                        Debug.Write(res.AccessToken + "/------------------------------Access Token");                       
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
       
    }
}
