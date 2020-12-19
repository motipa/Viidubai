using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vii.Models;

namespace Vii.Services
{
    public class UserDetails
    {
        private readonly string _apiBaseUrl;       
        public UserDetails()
        {
#if DEBUG
            _apiBaseUrl = "https://clubappapi20201206152856.azurewebsites.net/";
#else
            _apiBaseUrl = "https://clubappapi20201206152856.azurewebsites.net/";
#endif
        }
        public async Task<UserModel> GetCustomerDetails(string Email)
        {
            try
            {
                var result = await _apiBaseUrl
               .AppendPathSegment("api/reserve/" + Email + "")
               .GetAsync()
                .ReceiveJson<UserModel>();               
                return result;
            }
            catch (FlurlHttpException fex)
            {
                throw fex;
            }
        }
    }
}
