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

namespace KantriStore.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatigoriesPage : ContentPage
    {
        CategoryViewModel viewModel;

        public CatigoriesPage()
        {
            InitializeComponent();
            viewModel = new CategoryViewModel();
            BindingContext = viewModel;
        }
    }
}