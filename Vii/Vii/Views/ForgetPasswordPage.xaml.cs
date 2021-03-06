﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Vii.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vii.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgetPasswordPage : ContentPage
    {
        private SignUpViewModel _signUp;
        public ForgetPasswordPage()
        {
            InitializeComponent();
            SignUpViewModel signUp = new SignUpViewModel();
            _signUp = signUp;
            BindingContext = _signUp;
        }
        async void sendlink_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (Regex.Match(Email.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
                {
                    _signUp.userModel.Email = Email.Text;
                    _signUp.SendCodeforActivation(Email.Text);
                    await DisplayAlert("Success", "Password change link sent to your email", "OK");
                    UpdatePanel.IsVisible = true;
                }
                else
                {
                    lblError.Text = "Invalid Email Id";
                }
            }
            catch(Exception ex)
            {

            }
        }
        async void changepassword_Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Password.Text == ConfirmPassword.Text)
                {
                    _signUp.userModel.ActivationCode = ActivationCode.Text;
                    _signUp.userModel.Password = Password.Text;

                    int s = _signUp.OnupdatePassword();
                    if (s > 0)
                    {
                        await DisplayAlert("Success", "Your password has been changed successfully!", "OK");
                        Application.Current.MainPage = new SignInPage();
                    }
                }
                else
                {
                   await DisplayAlert("Error", "Password Mismatch", "OK");
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", "Password Not Updated", "OK");
            }
        }

        private void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string theBase = Password.Text;
                string confirmation = e.NewTextValue;
                // here is the change
                bool IsValid = (bool)theBase?.Equals(confirmation);

                ((Entry)sender).TextColor = IsValid ? Color.White : Color.Red;
                if (IsValid)
                {
                    btnChangePassword.IsEnabled = true;
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}