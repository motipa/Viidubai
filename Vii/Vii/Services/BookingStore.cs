﻿using ClubApp.Models.Booking;
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
        public BookingStore()
        {
#if DEBUG
            _apiBaseUrl = "https://clubappapi20201206152856.azurewebsites.net/";
#else
            _apiBaseUrl = "https://clubappapi20201206152856.azurewebsites.net/";
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
                return result;
            }
            catch (FlurlHttpException fex)
            {
                throw fex;                
            }
        }
    }
}
