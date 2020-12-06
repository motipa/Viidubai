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
        private readonly string _BookingRelativeUrlTemplate = "api/registration/";
        public SignUp()
        {
#if DEBUG
            _apiBaseUrl = "https://736de388413a.ngrok.io/";
#else
              //  _apiBaseUrl = "https:///";
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
                //var errorText = await fex.GetResponseStringAsync();
                //Debug.WriteLine(errorText);
                //return errorText;
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
                //  .GetJsonAsync<string>();
                return result;
            }
            catch (FlurlHttpException fex)
            {
                throw fex;
                //var errorText = await fex.GetResponseStringAsync();
                //Debug.WriteLine(errorText);
                //return errorText;
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
                //  .GetJsonAsync<string>();
                return result;
            }
            catch (FlurlHttpException fex)
            {
                throw fex;
                //var errorText = await fex.GetResponseStringAsync();
                //Debug.WriteLine(errorText);
                //return errorText;
            }
        }
    }

}
