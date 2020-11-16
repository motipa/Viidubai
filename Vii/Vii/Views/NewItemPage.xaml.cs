using System;
using System.Collections.Generic;
using System.ComponentModel;
using Vii.Models;
using Vii.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vii.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}