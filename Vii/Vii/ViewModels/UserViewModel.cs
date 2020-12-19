using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Vii.Helper;
using Vii.Models;
using Vii.Services;
using Xamarin.Forms;

namespace Vii.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private UserDetails _userDetails;

        public Command LoadCustCommand { get; set; }
        UserModel _user = new UserModel();
        public UserViewModel()
        {
            UserDetails userDetails = new UserDetails();
            _userDetails = userDetails;

            LoadCustCommand = new Command(async () => await LoadCustAsync());
        }
        public UserModel userDetails
        {
            get => _user;
            set
            {
                SetProperty(ref _user, value);
            }
        }
        public async Task<bool> LoadCustAsync()
        {
            if (IsBusy)
            {
                return false;
            }
            IsBusy = true;

            try
            {
                var d = await _userDetails.GetCustomerDetails(Settings.UserName);
                // var d= await _userDetails.GetCustomerDetails("alihashimc@gmail.com");
                userDetails.Email = d.Email;
                userDetails.FirstName = d.FirstName;
                userDetails.PhoneNumber = d.PhoneNumber;
                userDetails.Id = d.Id;
                //objmodel = items;
                //_user.Email=UserViewModel

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
