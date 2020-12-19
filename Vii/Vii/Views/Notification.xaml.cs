
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vii.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Notification : ContentPage
    {
        INotificationManager notificationManager;
        int notificationNumber = 0;
        public Notification()
        {
            InitializeComponent();
            
            notificationManager = DependencyService.Get<INotificationManager>();
            notificationManager.NotificationReceived += (sender, eventArgs) =>
            {
                var evtData = (NotificationEventArgs)eventArgs;
                ShowNotification(evtData.Title, evtData.Message);
            };
            callrefresh();
        }

       


        public async void callrefresh()
        {
            DistanceUnits distance;

            try
            {
                var location = await Geolocation.GetLocationAsync();

                if (location != null)
                {

                    var resul1t = Location.CalculateDistance(25.2262927, 55.2809619, location.Latitude, location.Longitude, 0);
                    if (resul1t < 3)
                    {

                        notificationNumber++;
                        string title = $"Greetings of the day";
                        string message = $"Vii dubai Welcomes you  !";
                        notificationManager.SendNotification(title, message);


                    }
                    else
                    {
                        await Task.Delay(8000);
                        callrefresh();
                    }
                    //  await Notifications(8000, location.Latitude + "-" + location.Longitude);


                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

        //public  async void callrefresh()
        //  {
        //      try
        //      {
        //          string message="";
        //          var locator = CrossGeolocator.Current;
        //          locator.DesiredAccuracy = 50;
        //          var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(2));
        //          double? latitude = Convert.ToDouble(position.Latitude);
        //          double? longitude = Convert.ToDouble(position.Longitude);
        //          if (latitude != null && longitude != null)
        //          {
        //              var revposition = new Xamarin.Forms.Maps.Position(latitude.Value, longitude.Value);
        //             var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(revposition);
        //             foreach (var address in possibleAddresses)
        //                message += address + "\n";
        //          }
        //          message += "error";

        //          await Notifications(8000, latitude + "-"+longitude) ;
        //      }
        //      catch (Exception ex)
        //      {
        //          await DisplayAlert("Notification", "Unable to get GPS Location " + ex, "Ok");
        //      }
        //  }


        public async Task Notifications(int milisec, string message)
        {
            
            await Task.Delay(milisec);
            await new SendNotification().SendTemplateNotificationsAsync(message);
            callrefresh();


        }

        void ShowNotification(string title, string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var msg = new Label()
                {
                    Text = $"Notification Received:\nTitle: {title}\nMessage: {message}"
                };
                messageDisplay.Children.Add(msg);
            });
        }

        public void AddMessage(string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (messageDisplay.Children.OfType<Label>().Where(c => c.Text == message).Any())
                {
                    // Do nothing, an identical message already exists
                }
                else
                {
                    Label label = new Label()
                    {
                        Text = message,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.Start
                    };
                    messageDisplay.Children.Add(label);
                }
            });
        }


    }
}