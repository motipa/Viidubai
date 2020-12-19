using ClubApp.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vii.Models;
using Vii.Services;
using Xamarin.Forms;

namespace Vii.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {
        private Page _page;
        public UserModel userModel { get; set; } = new UserModel();
        public SignUp signUp;
        private ISignUp _apiSignUpService;
        public SignUpViewModel()
        {
            SignUp sign = new SignUp();
            _apiSignUpService = sign;
        }
        public int OnRegister()
        {
            var res = _apiSignUpService.SignUpAsync(userModel);
            return res.Id;
        }
        public async void SendCodeforActivation(string Email)
        {
            await _apiSignUpService.SendActivationCode(Email);
        }        
        public int OnupdatePassword()
        {
            UserRegModel regModel = new UserRegModel();
            regModel.ActivationCode = userModel.ActivationCode;
            regModel.Password = userModel.Password;
            regModel.Email = userModel.Email;
            var res = _apiSignUpService.UpdatePassword(userModel);
            return 1;
        }
    }
}