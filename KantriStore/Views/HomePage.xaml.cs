using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using KantriStore.ViewModels;
using KantriStore.Services;
using Xamarin.Forms.PancakeView;
using KantriStore.Controls;
using KantriStore.Models;
using KantriStore.Views;

namespace KantriStore
{
    
    public partial class HomePage : ContentPage
    {
        public ApplicationViewModel viewModel;
        public static BasketViewModel BasketFromHomePage;

        const int animationSpeed = 250;
        public HomePage()
        {
            InitializeComponent();
            viewModel = new ApplicationViewModel();
            BasketFromHomePage = viewModel.Basket;
            BindingContext = viewModel;
        }

        public HomePage(BasketViewModel basket)
        {
            InitializeComponent();
            viewModel = new ApplicationViewModel();
            viewModel.Basket = basket;
            BindingContext = viewModel;
        }


        protected override async void OnAppearing()
        {
            await viewModel.GetProducts("https://kantriwebapp.azurewebsites.net/api/SaleProducts/", viewModel.SaleProducts);
            await viewModel.GetProducts("https://kantriwebapp.azurewebsites.net/api/HuntFishProducts/", viewModel.HuntFishProducts);
            await viewModel.GetProducts("https://kantriwebapp.azurewebsites.net/api/SpecifiedProducts/", viewModel.SpecifiedProducts);
            await viewModel.GetProducts("https://kantriwebapp.azurewebsites.net/api/NewProducts/", viewModel.NewProducts);
            viewModel.initialized = true;
            base.OnAppearing();
        }


        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            ProductDisplay element = sender as ProductDisplay;

            FakeProductCell.BindingContext = element.BindingContext;
            FakeProductCell.ImageOffsetX= element.ImageOffsetX;
            FakeProductCell.ImageOffsetY = element.ImageOffsetY;
            FakeProductCell.Opacity = 1;
            FakeProductCell.IsVisible = true;

            ((ApplicationViewModel)this.BindingContext).SeelectedProduct = element.BindingContext as Product;
            viewModel.PreviousSeelectedProduct = element.BindingContext as Product;

            var yScroll = ScrollContainerMain.ScrollY;
            var xScroll = ScrollContainerSide1.ScrollX;

            Rectangle rect = new Rectangle(
                x: ScrollContainerMain.X + element.X - xScroll,
                y: 330 + ScrollContainerMain.Y + element.Y - yScroll,
                width: element.Width,
                height: element.Height);

            AbsoluteLayout.SetLayoutBounds(FakeProductCell, rect);


            element.Opacity = 0.01;
            await FakeProductCell.ExpandToFill(this.Bounds);
            element.Opacity = 1;

            PagePopover.Opacity = 0;
            PagePopover.IsVisible = true;
            await PagePopover.Expand();

        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            ProductDisplay element = sender as ProductDisplay;

            FakeProductCell.BindingContext = element.BindingContext;
            FakeProductCell.ImageOffsetX = element.ImageOffsetX;
            FakeProductCell.ImageOffsetY = element.ImageOffsetY;
            FakeProductCell.Opacity = 1;
            FakeProductCell.IsVisible = true;

            ((ApplicationViewModel)this.BindingContext).SeelectedProduct = element.BindingContext as Product;
            viewModel.PreviousSeelectedProduct = element.BindingContext as Product;

            var yScroll = ScrollContainerMain.ScrollY;
            var xScroll = ScrollContainerSide3.ScrollX;

            Rectangle rect = new Rectangle(
                x: ScrollContainerMain.X + element.X - xScroll,
                y: 1150 - ScrollContainerMain.Y + element.Y - yScroll,
                width: element.Width,
                height: element.Height);

            AbsoluteLayout.SetLayoutBounds(FakeProductCell, rect);


            element.Opacity = 0.01;
            await FakeProductCell.ExpandToFill(this.Bounds);
            element.Opacity = 1;

            PagePopover.Opacity = 0;
            PagePopover.IsVisible = true;
            await PagePopover.Expand();
        }
        
        

        private async void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            ProductDisplay element = sender as ProductDisplay;

            FakeProductCell.BindingContext = element.BindingContext;
            FakeProductCell.ImageOffsetX = element.ImageOffsetX;
            FakeProductCell.ImageOffsetY = element.ImageOffsetY;
            FakeProductCell.Opacity = 1;
            FakeProductCell.IsVisible = true;

            ((ApplicationViewModel)this.BindingContext).SeelectedProduct = element.BindingContext as Product;
            viewModel.PreviousSeelectedProduct = element.BindingContext as Product;

            var yScroll = ScrollContainerMain.ScrollY;
            var xScroll = ScrollContainerSide2.ScrollX;

            Rectangle rect = new Rectangle(
                x: ScrollContainerMain.X + element.X - xScroll,
                y: 1500 - ScrollContainerMain.Y + element.Y - yScroll,
                width: element.Width,
                height: element.Height);

            AbsoluteLayout.SetLayoutBounds(FakeProductCell, rect);


            element.Opacity = 0.01;
            await FakeProductCell.ExpandToFill(this.Bounds);
            element.Opacity = 1;

            PagePopover.Opacity = 0;
            PagePopover.IsVisible = true;
            await PagePopover.Expand();
        }

        internal async void HidePopover()
        {
            await Task.WhenAll(
                new Task[]
                {
                    FakeProductCell.FadeTo(0),
                    PagePopover.FadeTo(0)
                });

            FakeProductCell.IsVisible = false;
            PagePopover.IsVisible = false;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BasketPage());
        }

        private void ProductDisplay_AddToCartClicked(object sender, EventArgs e)
        {
            ProductDisplay element = sender as ProductDisplay;
            Product item = element.BindingContext as Product;

            ((ApplicationViewModel)this.BindingContext).Basket.IncrementOrder(item);
        }
    }
}