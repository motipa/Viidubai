using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vii.Droid;
using Vii.Helper;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomTimePicker), typeof(ClassTimePicker))]
namespace Vii.Droid
{
   
    public class ClassTimePicker : TimePickerRenderer
    {
        public ClassTimePicker(Context context) : base(context)
        {
            AutoPackage = false;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.TimePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
               
                Control.Background = new ColorDrawable(Android.Graphics.Color.Gold);
                //Control.SetHintTextColor(global::Android.Graphics.Color.Rgb(182, 182, 182));

                //DrawBorder(view);

            }
        }
    }
}