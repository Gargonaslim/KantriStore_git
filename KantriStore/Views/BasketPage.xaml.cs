using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KantriStore.ViewModels;
using KantriStore.Models;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KantriStore.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasketPage : ContentPage
    {
        const int animationSpeed = 1200;
        public BasketPage(ref BasketViewModel Basket)
        {
            InitializeComponent();
            BindingContext = Basket;
            ExpandToFillBasket();
        }

        private async void ExpandToFillBasket ()
        {
            
            BackgroundBasket.CornerRadius = 40;
            await BackgroundBasket.TranslateTo(BackgroundBasket.Bounds.X, 200, animationSpeed / 2, Easing.SinInOut);
            _ = BasketDa.FadeTo(1, animationSpeed - 400, Easing.SinInOut);
            _ = OrderStatus.FadeTo(1, animationSpeed - 400, Easing.SinInOut);

        }

        private async void TapGestureRecognizer_Tapped111(object sender, EventArgs e)
        {
            await Order.ScaleTo(1.5);
            await Order.ScaleTo(1);

            _ = OrderSucc.TranslateTo(-500, 0, animationSpeed / 2, Easing.SinInOut);
            _ = Da.TranslateTo(-600, 0, animationSpeed, Easing.SinInOut);
            _ = BackHomeBox.TranslateTo(-700, 0, animationSpeed, Easing.SinInOut);
            _ = BackHome.TranslateTo(-700, 0, animationSpeed, Easing.SinInOut);
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await BackHomeBox.ScaleTo(1.5);
            await BackHomeBox.ScaleTo(1);
            await Navigation.PushAsync(new HomePage());
        }
    }
}