using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using KantriStore.ViewModels;
using KantriStore.Services;
using KantriStore.Models;
using KantriStore.Views;

namespace KantriStore
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
        {
            
            InitializeComponent();
            flyout.listview.ItemSelected += OnSelectedItem;
        }

        private void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutItemPage;
            if (item != null)
            {
                if (item.TargetPage.FullName != "KantriStore.HomePage")
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetPage, HomePage.BasketFromHomePage));
                else
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetPage, CatigoriesPage.BasketFromCategories));
                flyout.listview.SelectedItem = null;
                IsPresented = false;
            }
        }

        
    }
}
