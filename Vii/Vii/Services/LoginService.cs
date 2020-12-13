using ClubApp.Models.Auth;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Vii.Models;

namespace Vii.Services
{
    public class LoginService : ILogin
    {
        private const string CategoriesRelativeUrlTemplate = "api/auth/authorize";
        private readonly string _apiBaseUrl;


        public LoginService()
        {// set URL for central IAM for debug to dev console, prod in release mode.  Put this in so I dont have to keep switching the endpoint when flipping between prod and dev
#if DEBUG
            //_apiBaseUrl = "https://clubappapi20201206152856.azurewebsites.net/";
            _apiBaseUrl = "https://8d570789f71c.ngrok.io/";
#else
              //  _apiBaseUrl = "https:///";

#endif
        }
        public async Task<AuthorizationResponseModel> LoginAsync(AuthorizationModel authorization)
        {
            try
            {
                var result = await _apiBaseUrl
               .AppendPathSegment("api/auth/authorize")
               .PostJsonAsync(authorization)
                .ReceiveJson<AuthorizationResponseModel>();
                //  .GetJsonAsync<string>();
                return result;
            }
            catch (FlurlHttpException fex)
            {
                AuthorizationResponseModel res = new AuthorizationResponseModel();

                Debug.WriteLine(fex);
                res.AccessToken = string.Empty;
                throw fex;
            }
        }
        public async Task<AuthorizationResponseModel> RefreshAsync(RefreshRequest authorization)
        {

            try
            {

                RefreshRequest res = authorization;
                var result = await _apiBaseUrl
                        .AppendPathSegment("api/auth/authorize")
                         .PostJsonAsync(authorization)
                         .ReceiveJson<AuthorizationResponseModel>();

                return result;
            }
            catch (FlurlHttpException fex)
            {
                AuthorizationResponseModel res = new AuthorizationResponseModel();

                Debug.WriteLine(fex);
                res.AccessToken = string.Empty;
                return res;
            }


        }



    }
}
