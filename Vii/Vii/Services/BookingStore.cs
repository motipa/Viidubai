using ClubApp.Models.Booking;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vii.Models;
using Vii.ViewModels;

namespace Vii.Services
{
    public class BookingStore : IBookingStore
    {
        private readonly string _apiBaseUrl;
        private readonly string _BookingRelativeUrlTemplate = "api/reserve/";
        public BookingStore()
        {
#if DEBUG
            _apiBaseUrl = "https://bbe09c75dbff.ngrok.io/";

#else
              //  _apiBaseUrl = "https:///";
#endif
        }
        public async Task<TableBookingViewModel> BookingTables(BookingViewModel book)
        {
            try
            {
                var result = await _apiBaseUrl
               .AppendPathSegment("api/reserve/tablebooking")
               .PostJsonAsync(book)
                .ReceiveJson<TableBookingViewModel>();
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
