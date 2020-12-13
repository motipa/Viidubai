using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Text;
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
using static Android.Arch.Core.Internal.SafeIterableMap;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(ClassEntryBox))]
namespace Vii.Droid
{
    public class ClassEntryBox : EntryRenderer
    {
        public ClassEntryBox(Context context) : base(context)
        {
            //AutoPackage = false;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();

                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
                Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
                Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.White));

            }
        }

    }
}