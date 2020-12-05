using ClubApp.Models.Booking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vii.ViewModels;

namespace Vii.Services
{
    public interface IBookingStore
    {
        Task<TableBookingViewModel> BookingTables(BookingViewModel book);
    }
}
