using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using KantriStore.ViewModels;
using KantriStore.Models;
using Xamarin.Forms.Xaml;
using KantriStore.Views;

namespace KantriStore.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatigoriesPage : ContentPage
    {
        public static BasketViewModel BasketFromCategories;
        CategoryViewModel viewModel;

        public CatigoriesPage(BasketViewModel Basket)
        {
            InitializeComponent();
            BasketFromCategories = Basket;
            viewModel = new CategoryViewModel();
            BindingContext = viewModel;
        }
    }
}