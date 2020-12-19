using ClubApp.Models.User;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vii.Models;

namespace Vii.Services
{
    public class SignUp : ISignUp
    {
        private readonly string _apiBaseUrl;        
        public SignUp()
        {
#if DEBUG
            _apiBaseUrl = "https://clubappapi20201206152856.azurewebsites.net/";           
#else
            _apiBaseUrl = "https://clubappapi20201206152856.azurewebsites.net/";
#endif
        }
        public async Task SendActivationCode(string Email)
        {
            try
            {
                var result = await _apiBaseUrl
               .AppendPathSegment("api/registration/forgotpassword/" + Email)
               .GetAsync();
            }
            catch (FlurlHttpException fex)
            {
                throw fex;
            }
        }       
        public async Task<UserViewModel> SignUpAsync(UserModel userModel)
        {
            try
            {
                var result = await _apiBaseUrl
               .AppendPathSegment("api/registration/userregistration")
               .PostJsonAsync(userModel)
                .ReceiveJson<UserViewModel>();               
                return result;
            }
            catch (FlurlHttpException fex)
            {
                throw fex;
            }
        }
        public async Task<UserViewModel> UpdatePassword(UserModel userModel)
        {
            try
            {
                var result = await _apiBaseUrl
               .AppendPathSegment("api/registration/updatepassword")
               .PostJsonAsync(userModel)
                .ReceiveJson<UserViewModel>();               
                return result;
            }
            catch (FlurlHttpException fex)
            {
                throw fex;               
            }
        }
        public async Task<UserModel> EmailVerification(string Email)
        {
            try
            {
                var success = await _apiBaseUrl
               .AppendPathSegment("api/registration/newregister/" + Email)
               .GetAsync()
                .ReceiveJson<UserModel>();               
                return success;
            }
            catch (FlurlHttpException fex)
            {
                throw fex;                
            }
        }
    }

}
