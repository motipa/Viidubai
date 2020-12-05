using ClubApp.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vii.Models;

namespace Vii.Services
{
    public interface ISignUp
    {
        Task<UserViewModel> SignUpAsync(UserModel userModel);
        Task SendActivationCode(string Email);
        Task<UserViewModel> UpdatePassword(UserModel userModel);
    }
}
