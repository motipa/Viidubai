using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vii.Helper;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vii.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodMenuPage : ContentPage
    {
        string username = Settings.UserName;
        public FoodMenuPage()
        {
            InitializeComponent();
        }
        private void takeoverthursday_Button_Clicked(object sender, EventArgs e)
        {


        }

        private void redmadnessfriday_Button_Clicked(object sender, EventArgs e)
        {

        }

        private void uptown_monday_Button_Clicked(object sender, EventArgs e)
        {

        }
        protected override async void OnAppearing()
        {
            if (username != "")
            {
                base.OnAppearing();
                // imgName.Source = ImageSource.FromResource("tablebook2.jpg");
            }
            else
            {
                Application.Current.MainPage = new SignInPage();

            }
        }

    }
}