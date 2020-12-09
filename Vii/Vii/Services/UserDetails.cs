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
        private readonly string _BookingRelativeUrlTemplate = "api/reserve/";
        public UserDetails()
        {
#if DEBUG
            _apiBaseUrl = "https://2107b862141d.ngrok.io/";

#else
              //  _apiBaseUrl = "https:///";
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
