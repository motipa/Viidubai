using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vii.Helper;
using Vii.Models;
using Vii.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vii.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservationPage : ContentPage
    {
        int TotalCount = 0;
        private readonly TableBookingViewModel _book;
        AppShell MainPage;
        public UserModel user = new UserModel();
        string username = Settings.UserName;
        public ReservationPage()
        {
            InitializeComponent();
                TableBookingViewModel book;
                book = new TableBookingViewModel();
                _book = book;
                BindingContext = _book;
           
        }
        private bool _canClose = true;
        List<string> array = new List<string>();
        void OnImageButtonClicked(object sender, EventArgs e)
        {

            Button btnTable = (Button)sender;
            string tid = btnTable.ClassId;
            if (array.Contains(tid))
            {
                DisplayAlert("Reservation", "Table-" + tid + " is Alraedy Reserved", "OK");
            }
            else
            {
                if (tid != null)
                {
                    array.Add(tid);
                    if (tableDetails.Text != null)
                    {
                        tableDetails.Text += ",";
                    }
                    if (_book.SelectedTags != null)
                    {
                        _book.SelectedTags += ",";
                    }
                    tableDetails.Text += "Table-" + tid;
                    _book.SelectedTags += "Table-" + tid;
                    TotalCount++;

                    if (_canClose)
                    {
                        ShowExitDialog();
                    }
                    //return _canClose;
                }
            }

        }
        private async void ShowExitDialog()
        {
            var answer = await DisplayAlert("Confirmation", "Reserved Table is :'" + tableDetails.Text + "' ?", "Yes", "No");
            if (answer)
            {
                _canClose = false;

            }
            else
            {
                tableDetails.Text = null;
                _book.SelectedTags = null;
                array.Clear();
            }
            _canClose = true;
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            DateTime f = FromDate.DateTime;
            DateTime t = ToDate.DateTime;
            DateTime current = DateTime.Now;
            if (Venue.SelectedItem != null)
            {
                if (current < f)
                {
                    if (tableDetails.Text != null)
                    {
                        if (f > t)
                        {
                            DisplayAlert("Error", "To Date or Time Invalid", "OK");
                        }
                        else
                        {
                            _book.BookModel.customerName = CustName.Text;
                            _book.BookModel.bookedTable = tableDetails.Text;
                            _book.BookModel.bookedCount = TotalCount;
                            _book.BookModel.fromDate = FromDate.DateTime;
                            _book.BookModel.toDate = ToDate.DateTime;
                            _book.BookModel.venue = Venue.SelectedItem.ToString();
                            _book.BookModel.specialNote = SpecialNotes.Text;
                            if (shisha.IsToggled == true)
                            {
                                _book.BookModel.shisha = "YES";
                            }
                            else
                            {
                                _book.BookModel.shisha = "NO";
                            }
                            int s = _book.OnAddItem();
                            if (s == 1)
                            {
                                DisplayAlert("Reservation", "Table Reservation Successfull", "OK");
                                shisha.IsToggled = false;
                                tableDetails.Text = null;
                                SpecialNotes.Text = "";
                                array.Clear();
                            }
                            else
                            {
                                DisplayAlert("Reservation", "Server down, Please try later", "OK");
                            }
                        }
                    }
                    else
                    {
                        DisplayAlert("Error", "Choose Table", "OK");
                    }
                }
                else
                {
                    DisplayAlert("Error", "Invalid Time", "OK");
                }
            }

            else
            {
                DisplayAlert("Error", "Select Venue", "OK");
            }
        }
        protected override async void OnAppearing()
        {
            if (username != "")
            {
                base.OnAppearing();
                await _book._userViewModel.LoadCustAsync();
                CustName.Text = _book._userViewModel.userDetails.FirstName;
                // imgName.Source = ImageSource.FromResource("tablebook2.jpg");
            }
            else
            {
                await Navigation.PushAsync(new SignInPage());

            }
        }
        private void RedRoom_Tapped(object sender, EventArgs e)
        {
            SecretGardenView.IsVisible = false;
            RedRoomView.IsVisible = true;
            Redmap.TextColor = Color.Red;
            Secretmap.TextColor = Color.White;
        }
        private void ClickSecretGarden_Tapped(object sender, EventArgs e)
        {
            SecretGardenView.IsVisible = true;
            Secretmap.TextColor = Color.Red;
            Redmap.TextColor = Color.White;
            RedRoomView.IsVisible = false;
        }

        void HomeClick(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new HomePage());
            //MainPage = new NavigationPage(new HomePage());
            Application.Current.MainPage = new  AppShell();
        }

        private void Logout(object sender, EventArgs e)
        {

        }

        private void OnAmber_ImageButtonClicked(object sender, EventArgs e)
        {

        }
    }
}