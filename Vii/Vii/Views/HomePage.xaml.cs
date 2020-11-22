using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamd.ImageCarousel.Forms.Plugin.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Vii.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        ObservableCollection <FileImageSource> imageSources = new ObservableCollection <FileImageSource>();
        public HomePage()
        {
            InitializeComponent();
            // //var image = new Image { Source = "Secretgarden.jpg" };
            // //             //Create a collection of ImageSources
            //     imageSources.Add("Secretgarden.jpg");
            //     imageSources.Add("reservation.png");
            //     imageSources.Add("support.png");

            ////  imgSlider.Images = imageSources;
            var images = new List<string>
            {
               "Secretgarden.jpg","reservation.png","support.png"
            };
            MainCarouselView.ItemsSource = images;
            MainCarouselView1.ItemsSource = images;
            Device.StartTimer(TimeSpan.FromSeconds(5), (Func<bool>)(() =>
            {
                MainCarouselView.Position = (MainCarouselView.Position + 1) % images.Count;
                MainCarouselView1.Position = (MainCarouselView1.Position + 1) % images.Count;
                return true;
            }));
        }
        //void OnImageButtonClicked(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new EventPage());
        //}
        //void OnImageButtonClicked1(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new EventPage());
        //}
        //void OnImageButtonClicked2(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new EventPage());
        //}
    }
}