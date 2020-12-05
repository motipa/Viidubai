using ClubApp.Models.Booking;
using System;
using System.Collections.Generic;
using System.Text;
using Vii.Models;
using Vii.Services;

namespace Vii.ViewModels
{
   public class TableBookingViewModel : BaseViewModel
    {
        private BookingStore _apiBookServices;
        private BookingModel _book = new BookingModel();
        private UserModel _user = new UserModel();
       // public VenueViewDetailsModel _venueViewModel { get; set; }
        public UserViewModel _userViewModel { get; set; }
        public TableBookingViewModel()
        {
            UserViewModel userViewModel = new UserViewModel();
            _userViewModel = userViewModel;
        }
        private string _selectedTags;

        public string SelectedTags
        {
            get => _selectedTags;
            set
            {
                SetProperty(ref _selectedTags, value);
                //SyncCanCreate();
            }
        }
        public BookingModel BookModel
        {
            get => _book;
            set
            {
                SetProperty(ref _book, value);
            }
        }
        public UserModel userModelDetails
        {
            get => _user;
            set
            {
                SetProperty(ref _user, value);
            }
        }
        public int OnAddItem()
        {
            try
            {
                //var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _apiBookServices = new BookingStore();
                BookingViewModel objBook = new BookingViewModel();
                objBook.BookingDateTimeFrom = BookModel.fromDate;
                objBook.BookingDateTimeTo = BookModel.toDate;
                objBook.NumberOfBookedTable = BookModel.bookedCount;
                objBook.TableNum = BookModel.bookedTable;
                objBook.shisha = BookModel.shisha;
                objBook.Venue = BookModel.venue;
                objBook.CustId = _userViewModel.userDetails.Id;

                objBook.sendEmail = new ClubApp.Models.Email.SendEmail();
                objBook.sendEmail.subject = "App-Table Reservation Request";
                objBook.sendEmail.toEmail = "alihashimc@gmail.com";
                objBook.Customer = new ClubApp.Models.Customer.CustomerModel();
                //objBook.Customer.Name = userModelDetails.FirstName;
                objBook.Customer.Name = _userViewModel.userDetails.FirstName;
                objBook.Customer.Email = _userViewModel.userDetails.Email;
                objBook.Customer.Phone = _userViewModel.userDetails.PhoneNumber;
                //test
                objBook.VenueId = new Guid();
                objBook.SpecialNote = BookModel.specialNote;
                var res = _apiBookServices.BookingTables(objBook);
                return 1;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
    }
}
