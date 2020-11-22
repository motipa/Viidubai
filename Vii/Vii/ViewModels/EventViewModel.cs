using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Vii.ViewModels
{
    public class EventViewModel : ContentPage
    {
        public EventViewModel()
        {
            Title = "EVENT";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("HomePage"));
        }

        public ICommand OpenWebCommand { get; }
    }
}