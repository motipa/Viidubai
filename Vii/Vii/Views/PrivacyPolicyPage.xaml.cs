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
    public partial class PrivacyPolicyPage : ContentPage
    {
        string username = Settings.UserName;
        public PrivacyPolicyPage()
        {
            InitializeComponent();
        }
        

    }
}