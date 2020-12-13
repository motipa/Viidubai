using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Vii.ViewModels
{
   public class TimeViewModel : ContentView, INotifyPropertyChanged
    {
        public Entry _entry { get; private set; } = new Entry();
        
        //public DatePicker _datePicker { get; private set; } = new DatePicker() { MinimumDate = DateTime.Today, IsVisible = false };
        public TimePicker _timePicker { get; private set; } = new TimePicker() { IsVisible = false };
        string _stringFormat { get; set; }
        public string StringFormat { get { return _stringFormat ?? " hh:mm tt"; } set { _stringFormat = value; } }
        public DateTime DateTime
        {
            get { return (DateTime)GetValue(DateTimeProperty); }
            set { SetValue(DateTimeProperty, value); OnPropertyChanged("DateTime"); }
        }

        private TimeSpan _time
        {
            get
            {
                return TimeSpan.FromTicks(DateTime.Ticks);
            }
            set
            {
                DateTime = new DateTime(DateTime.Date.Ticks).AddTicks(value.Ticks);
            }
        }

        private DateTime _date
        {
            get
            {
                return DateTime.Date;
            }
            set
            {
                DateTime = new DateTime(DateTime.TimeOfDay.Ticks).AddTicks(value.Ticks);
            }
        }

        BindableProperty DateTimeProperty = BindableProperty.Create("DateTime", typeof(DateTime), typeof(TimeViewModel), DateTime.Now, BindingMode.TwoWay, propertyChanged: DTPropertyChanged);

        public TimeViewModel()
        {
            BindingContext = this;
            //_datePicker.BackgroundColor = Color.LightBlue;

            Content = new StackLayout()
            {
                Children =
            {
                //_datePicker,
                _timePicker,
                _entry
            }
            };

            //_datePicker.SetBinding<TimeViewModel>(DatePicker.DateProperty, p => p._date);
             _timePicker.SetBinding<TimeViewModel>(TimePicker.TimeProperty, p => p._time);
            _timePicker.BackgroundColor = Color.Gold;
             _timePicker.Unfocused += (sender, args) => _time = _timePicker.Time;
           // _datePicker.Focused += (s, a) => UpdateEntryText();

            GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() => _timePicker.Focus())
            });
            _entry.Focused += (sender, args) =>
            {
                Device.BeginInvokeOnMainThread(() => _timePicker.Focus());
            };
            //_timePicker.Unfocused += (sender, args) =>
            //{
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        _timePicker.Focus();
            //        //_date = _datePicker.Date;
            //        UpdateEntryText();
            //    });
            //};
        }

        private void UpdateEntryText()
        {
            _entry.Text = DateTime.ToString(StringFormat);
            _entry.TextColor = Color.Black;
            _timePicker.BackgroundColor = Color.White;
        }

        static void DTPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var timePicker = (bindable as TimeViewModel);           
            timePicker.UpdateEntryText();
            
        }
    }
}
