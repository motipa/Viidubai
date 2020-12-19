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
    public partial class GalleryPage : ContentPage
    {
        int click = 0;
        string username = Settings.UserName;
        public GalleryPage()
        {
            InitializeComponent();
        }
        ContentPage detailsPage = new ContentPage
        {
            BackgroundColor = Color.Black,// Color.FromHex("#00F0F8FF"),
            Padding = new Thickness(20, 20, 20, 20),
            WidthRequest = 50,
            HeightRequest = 80

        };
        //StackLayout stack = new StackLayout { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
        private async void image_click_gesture1(object sender, EventArgs e)
        {
            try
            {
                if (detailsPage.Content == null)
                {
                    detailsPage.Content = glryimg1;
                    glryimg1.Aspect = Aspect.AspectFit;
                    await Application.Current.MainPage.Navigation.PushModalAsync(detailsPage, true);
                }
                else
                {
                    await Navigation.PopModalAsync(true);
                    detailsPage.Content = null;
                }
                //  }
            }
            catch (Exception ex)
            {

            }
        }
        private async void image_click_gesture2(object sender, EventArgs e)
        {
            try
            {
                if (detailsPage.Content == null)
                {
                    detailsPage.Content = glryimg2;
                    glryimg1.Aspect = Aspect.AspectFit;
                    await Navigation.PushModalAsync(detailsPage, false);
                }
                else
                {
                    await Navigation.PopModalAsync(true);
                    detailsPage.Content = null;
                }

            }
            catch (Exception ex)
            {

            }
        }
        private async void image_click_gesture3(object sender, EventArgs e)
        {
            try
            {
                if (detailsPage.Content == null)
                {
                    detailsPage.Content = glryimg3;
                    glryimg1.Aspect = Aspect.AspectFit;
                    await Navigation.PushModalAsync(detailsPage, false);
                }
                else
                {
                    await Navigation.PopModalAsync(true);
                    detailsPage.Content = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private async void image_click_gesture4(object sender, EventArgs e)
        {
            try
            {
                if (detailsPage.Content == null)
                {
                    detailsPage.Content = glryimg4;
                    glryimg1.Aspect = Aspect.AspectFit;
                    await Navigation.PushModalAsync(detailsPage, false);
                }
                else
                {
                    await Navigation.PopModalAsync(true);
                    detailsPage.Content = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private async void image_click_gesture5(object sender, EventArgs e)
        {
            try
            {
                if (detailsPage.Content == null)
                {
                    detailsPage.Content = glryimg5;
                    glryimg1.Aspect = Aspect.AspectFit;
                    await Navigation.PushModalAsync(detailsPage, false);
                }

                else
                {
                    await Navigation.PopModalAsync(true);
                    detailsPage.Content = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private async void image_click_gesture6(object sender, EventArgs e)
        {
            try
            {
                if (detailsPage.Content == null)
                {
                    detailsPage.Content = glryimg6;
                    glryimg1.Aspect = Aspect.AspectFit;
                    await Navigation.PushModalAsync(detailsPage, false);
                }

                else
                {
                    await Navigation.PopModalAsync(true);
                    detailsPage.Content = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private async void image_click_gesture7(object sender, EventArgs e)
        {
            try
            {
                if (detailsPage.Content == null)
                {
                    detailsPage.Content = glryimg7;
                    glryimg1.Aspect = Aspect.AspectFit;
                    await Navigation.PushModalAsync(detailsPage, false);
                }
                else
                {
                    await Navigation.PopModalAsync(true);
                    detailsPage.Content = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private async void image_click_gesture8(object sender, EventArgs e)
        {
            try
            {
                if (detailsPage.Content == null)
                {
                    detailsPage.Content = glryimg8;
                    glryimg1.Aspect = Aspect.AspectFit;
                    await Navigation.PushModalAsync(detailsPage, false);
                }
                else
                {
                    await Navigation.PopModalAsync(true);
                    detailsPage.Content = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private async void image_click_gesture9(object sender, EventArgs e)
        {
            try
            {
                if (detailsPage.Content == null)
                {
                    detailsPage.Content = glryimg9;
                    glryimg1.Aspect = Aspect.AspectFit;
                    await Navigation.PushModalAsync(detailsPage, false);
                }
                else
                {
                    await Navigation.PopModalAsync(true);
                    detailsPage.Content = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private async void image_click_gesture10(object sender, EventArgs e)
        {
            try
            {
                if (detailsPage.Content == null)
                {
                    detailsPage.Content = glryimg10;
                    glryimg1.Aspect = Aspect.AspectFit;
                    await Navigation.PushModalAsync(detailsPage, false);
                }
                else
                {
                    await Navigation.PopModalAsync(true);
                    detailsPage.Content = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private async void image_click_gesture11(object sender, EventArgs e)
        {
            try
            {
                if (detailsPage.Content == null)
                {
                    detailsPage.Content = glryimg11;
                    glryimg1.Aspect = Aspect.AspectFit;
                    await Navigation.PushModalAsync(detailsPage, false);
                }
                else
                {
                    await Navigation.PopModalAsync(true);
                    detailsPage.Content = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private async void image_click_gesture12(object sender, EventArgs e)
        {
            try
            {
                if (detailsPage.Content == null)
                {
                    detailsPage.Content = glryimg12;
                    glryimg1.Aspect = Aspect.AspectFit;
                    await Navigation.PushModalAsync(detailsPage, false);
                }
                else
                {
                    await Navigation.PopModalAsync(true);
                    detailsPage.Content = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private async void image_click_gesture13(object sender, EventArgs e)
        {
            try
            {
                if (detailsPage.Content == null)
                {
                    detailsPage.Content = glryimg13;
                    glryimg1.Aspect = Aspect.AspectFit;
                    await Navigation.PushModalAsync(detailsPage, false);
                }
                else
                {
                    await Navigation.PopModalAsync(true);
                    detailsPage.Content = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private async void image_click_gesture14(object sender, EventArgs e)
        {
            try
            {
                if (detailsPage.Content == null)
                {
                    detailsPage.Content = glryimg14;
                    glryimg1.Aspect = Aspect.AspectFit;
                    await Navigation.PushModalAsync(detailsPage, false);
                }
                else
                {
                    await Navigation.PopModalAsync(true);
                    detailsPage.Content = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private async void image_click_gesture15(object sender, EventArgs e)
        {
            try
            {
                if (detailsPage.Content == null)
                {
                    detailsPage.Content = glryimg15;
                    glryimg1.Aspect = Aspect.AspectFit;
                    await Navigation.PushModalAsync(detailsPage, false);
                }
                else
                {
                    await Navigation.PopModalAsync(true);
                    detailsPage.Content = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private async void image_click_gesture16(object sender, EventArgs e)
        {
            try
            {
                if (detailsPage.Content == null)
                {
                    detailsPage.Content = glryimg16;
                    glryimg1.Aspect = Aspect.AspectFit;
                    await Navigation.PushModalAsync(detailsPage, false);
                }
                else
                {
                    await Navigation.PopModalAsync(true);
                    detailsPage.Content = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private async void image_click_gesture17(object sender, EventArgs e)
        {
            try
            {
                if (detailsPage.Content == null)
                {
                    detailsPage.Content = glryimg17;
                    glryimg1.Aspect = Aspect.AspectFit;
                    await Navigation.PushModalAsync(detailsPage, false);
                }
                else
                {
                    await Navigation.PopModalAsync(true);
                    detailsPage.Content = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private async void image_click_gesture18(object sender, EventArgs e)
        {
            try
            {
                if (detailsPage.Content == null)
                {
                    detailsPage.Content = glryimg18;
                    glryimg1.Aspect = Aspect.AspectFit;
                    await Navigation.PushModalAsync(detailsPage, false);
                }
                else
                {
                    await Navigation.PopModalAsync(true);
                    detailsPage.Content = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private async void image_click_gesture19(object sender, EventArgs e)
        {
            try
            {
                if (detailsPage.Content == null)
                {
                    detailsPage.Content = glryimg19;
                    glryimg1.Aspect = Aspect.AspectFit;
                    await Navigation.PushModalAsync(detailsPage, false);
                }
                else
                {
                    await Navigation.PopModalAsync(true);
                    detailsPage.Content = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private async void image_click_gesture20(object sender, EventArgs e)
        {
            try
            {
                if (detailsPage.Content == null)
                {
                    detailsPage.Content = glryimg20;
                    glryimg1.Aspect = Aspect.AspectFit;
                    await Navigation.PushModalAsync(detailsPage, false);
                }
                else
                {
                    await Navigation.PopModalAsync(true);
                    detailsPage.Content = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private async void image_click_gesture21(object sender, EventArgs e)
        {
            try
            {
                if (detailsPage.Content == null)
                {
                    detailsPage.Content = glryimg21;
                    glryimg1.Aspect = Aspect.AspectFit;
                    await Navigation.PushModalAsync(detailsPage, false);
                }
                else
                {
                    await Navigation.PopModalAsync(true);
                    detailsPage.Content = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private async void image_click_gesture22(object sender, EventArgs e)
        {
            try
            {
                if (detailsPage.Content == null)
                {
                    detailsPage.Content = glryimg22;
                    glryimg1.Aspect = Aspect.AspectFit;
                    await Navigation.PushModalAsync(detailsPage, false);
                }
                else
                {
                    await Navigation.PopModalAsync(true);
                    detailsPage.Content = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private async void image_click_gesture23(object sender, EventArgs e)
        {
            try
            {
                if (detailsPage.Content == null)
                {
                    detailsPage.Content = glryimg23;
                    glryimg1.Aspect = Aspect.AspectFit;
                    await Navigation.PushModalAsync(detailsPage, false);
                }
                else
                {
                    await Navigation.PopModalAsync(true);
                    detailsPage.Content = null;
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected override async void OnAppearing()
        {
            if (username != "")
            {
                base.OnAppearing();
            }
            else
            {
                Application.Current.MainPage = new SignInPage();
            }
        }
    }
}