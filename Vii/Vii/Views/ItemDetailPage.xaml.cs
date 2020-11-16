using System.ComponentModel;
using Vii.ViewModels;
using Xamarin.Forms;

namespace Vii.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}