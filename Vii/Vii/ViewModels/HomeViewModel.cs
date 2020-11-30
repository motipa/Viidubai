using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Vii.ViewModels
{
    public class HomeViewModel : ContentPage
    {
        public ImageSource image
        {
            get; set;
        }

        public string Heading { get; set; }
        public string Caption { get; set; }
        public HomeViewModel()
        {
            Title = "HOME";


            OpenWebCommand = new Command(async () => await Browser.OpenAsync("HomePage"));
        }

        public ICommand OpenWebCommand { get; }
    }
}