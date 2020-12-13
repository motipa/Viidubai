using System;
using System.Collections.Generic;
using System.Globalization;
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
        public List<int> Person = new List<int>();
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
                    string td = tableDetails.Text;
                    if (td == null) td = "";
                    array.Add(tid);
                    if (td != "")
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
                tableDetails.Text = "";
                _book.SelectedTags = null;
                array.Clear();
            }
            _canClose = true;
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            string fdate = FromDate.DateTime.ToString();
            DateTime t = Convert.ToDateTime(fdate);
            //DateTime t = ToDate.DateTime;
            TimeSpan selectTime = timepick._timePicker.Time;
            // DateTime selectDateTime = DateTime.ParseExact(fdate + " " + selectTime, "dd/MM/yy hh:mm:ss tt", CultureInfo.GetCultureInfo("en-IN"));

            string current = DateTime.Now.ToShortDateString();
            DateTime c = Convert.ToDateTime(current);
            TimeSpan now = DateTime.Now.TimeOfDay;

            string td = tableDetails.Text;
            if (c <= t)
            {
                if (now < selectTime)
                {
                    if (td != "")
                    {
                        if (NumberofPerson.SelectedItem != null)
                        {
                            _book.BookModel.customerName = CustName.Text;
                            _book.BookModel.bookedTable = tableDetails.Text;
                            _book.BookModel.bookedCount = TotalCount;
                            _book.BookModel.fromDate = FromDate.DateTime;
                            _book.BookModel.Time = timepick._timePicker.Time;
                            _book.BookModel.numberOfPerson = Convert.ToInt32(NumberofPerson.SelectedItem.ToString());
                            _book.BookModel.venue = Venue.Text;
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
                                DisplayAlert("Reservation", "The Table Reservation Request is Success", "OK");
                                DisplayAlert.IsVisible = true;
                                shisha.IsToggled = false;
                                tableDetails.Text = "";
                                SpecialNotes.Text = "";
                                Venue.Text = "";
                                array.Clear();
                            }
                            else
                            {
                                DisplayAlert("Reservation", "Server down, Please try later", "OK");
                            }
                        }
                        else
                        {
                            DisplayAlert("Error", "Select Number of Person", "OK");
                            NumberofPerson.Focus();
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
                    timepick.Focus();
                }
            }
            else
            {
                DisplayAlert("Error", "Invalid Date", "OK");
                FromDate.Focus();
            }

        }
        protected override async void OnAppearing()
        {
            if (username != "")
            {
                base.OnAppearing();
                await _book._userViewModel.LoadCustAsync();
                CustName.Text = _book._userViewModel.userDetails.FirstName;
                tableDetails.Text = "";
                // imgName.Source = ImageSource.FromResource("tablebook2.jpg");
                Venue.Text = "SECRET GARDEN";

                for (int i = 1; i <= 15; i++)
                {
                    NumberofPerson.Items.Add(i.ToString());
                }
            }
            else
            {
                await Navigation.PushAsync(new Vii.Views.SignInPage());
            }
        }
        private void RedRoom_Tapped(object sender, EventArgs e)
        {
            SecretGardenView.IsVisible = false;
            RedRoomView.IsVisible = true;
            Redmap.TextColor = Color.Gold;
            Secretmap.TextColor = Color.White;
            AmberHallview.IsVisible = false;
            Amberhall.TextColor = Color.White;
            Venue.Text = "RED ROOM";
            tableDetails.Text = "";
            SecretGardenViewImage.IsVisible = false;
            SecretGardenView.IsVisible = false;
            RedRoomView.IsVisible = false;
            RedRoomViewImage.IsVisible = true;
            AmberHallImage.IsVisible = false;
            AmberHallview.IsVisible = false;
        }
        private void ClickSecretGarden_Tapped(object sender, EventArgs e)
        {
            SecretGardenView.IsVisible = true;
            AmberHallview.IsVisible = false;
            Amberhall.TextColor = Color.White;
            Secretmap.TextColor = Color.Gold;
            Redmap.TextColor = Color.White;
            RedRoomView.IsVisible = false;
            Venue.Text = "SECRET GARDEN";
            tableDetails.Text = "";
            SecretGardenViewImage.IsVisible = true;
            SecretGardenView.IsVisible = false;
            RedRoomView.IsVisible = false;
            RedRoomViewImage.IsVisible = false;
            AmberHallImage.IsVisible = false;
            AmberHallview.IsVisible = false;
        }
        private void OnAmber_ImageButtonClicked(object sender, EventArgs e)
        {
            ImageButton btnTables = (ImageButton)sender;
            string tids = btnTables.ClassId;
            if (array.Contains(tids))
            {
                DisplayAlert("Reservation", "Table-" + tids + " is Already Selected!", "OK");
            }
            else
            {
                if (tids != null)
                {
                    string tds = tableDetails.Text;
                    if (tds == null) tds = "";
                    array.Add(tids);
                    if (tds != "")
                    {
                        tableDetails.Text += ",";
                    }
                    if (_book.SelectedTags != null)
                    {
                        _book.SelectedTags += ",";
                    }
                    tableDetails.Text += "Table-" + tids;
                    _book.SelectedTags += "Table-" + tids;
                    TotalCount++;

                    if (_canClose)
                    {
                        ShowExitDialog();
                    }
                    //return _canClose;
                }
            }
        }

        private void Amberhall_Tapped(object sender, EventArgs e)
        {
            SecretGardenView.IsVisible = false;
            Secretmap.TextColor = Color.White;
            Redmap.TextColor = Color.White;
            RedRoomView.IsVisible = false;
            AmberHallview.IsVisible = true;
            Amberhall.TextColor = Color.Gold;
            Venue.Text = "AMBER HALL";
            tableDetails.Text = "";
            SecretGardenViewImage.IsVisible = false;
            SecretGardenView.IsVisible = false;
            RedRoomView.IsVisible = false;
            RedRoomViewImage.IsVisible = false;
            AmberHallImage.IsVisible = true;
            AmberHallview.IsVisible = false;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            DisplayAlert.IsVisible = false;
        }

        private void image_click_SecretGardenViewImage(object sender, EventArgs e)
        {
            SecretGardenViewImage.IsVisible = false;
            SecretGardenView.IsVisible = true;
            RedRoomView.IsVisible = false;
            RedRoomViewImage.IsVisible = false;
            AmberHallImage.IsVisible = false;
            AmberHallview.IsVisible = false;
        }

        private void image_click_RedRoomnViewImage(object sender, EventArgs e)
        {
            SecretGardenViewImage.IsVisible = false;
            SecretGardenView.IsVisible = false;
            RedRoomView.IsVisible = true;
            RedRoomViewImage.IsVisible = false;
            AmberHallImage.IsVisible = false;
            AmberHallview.IsVisible = false;

        }
        private void image_click_AmberHallImage(object sender, EventArgs e)
        {
            SecretGardenViewImage.IsVisible = false;
            SecretGardenView.IsVisible = false;
            RedRoomView.IsVisible = false;
            RedRoomViewImage.IsVisible = false;
            AmberHallImage.IsVisible = false;
            AmberHallview.IsVisible = true;
        }
    }
}