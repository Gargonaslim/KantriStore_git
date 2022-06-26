using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KantriStore.ViewModels;
using KantriStore.Models;

namespace KantriStore.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDisplay : ContentView
    {
        const int animationSpeed = 400;
        public ProductDisplay()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ImageOffsetYProperty =
            BindableProperty.Create(nameof(ImageOffsetY), typeof(int), typeof(ProductDisplay), 0);

        public int ImageOffsetY 
        { 
            get => (int)GetValue(ImageOffsetYProperty); 
            set => SetValue(ImageOffsetYProperty, value); 
        }

        public static readonly BindableProperty ImageOffsetXProperty =
            BindableProperty.Create(nameof(ImageOffsetX), typeof(int), typeof(ProductDisplay), 0);

        public int ImageOffsetX
        {
            get => (int)GetValue(ImageOffsetXProperty);
            set => SetValue(ImageOffsetXProperty, value);
        }

        protected override void OnPropertyChanged ([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == ImageOffsetYProperty.PropertyName)
            {
                ProductImage.TranslationY = ImageOffsetY;
            }

            if (propertyName == ImageOffsetXProperty.PropertyName)
            {
                ProductImage.TranslationX = ImageOffsetX;

            }
        }

        public event EventHandler ProductClicked;
        public event EventHandler ProductsTwoClicked;
        public event EventHandler ProductsThreeClicked;
        public event EventHandler AddToCartClicked;

        internal async Task ExpandToFill(Rectangle bounds)
        {
            ProductBackground.Opacity = .5;
            NameLabel.Opacity = 1;
            PriceLabel.Opacity = 1;
            FavouritesButton.Opacity = 1;
            BasketButton.Opacity = 1;
            ProductImage.Scale = 1;
            ProductImage.TranslationX = ImageOffsetX;
            ProductImage.TranslationY = ImageOffsetY;

            var destRect = new Rectangle(
            x: (bounds.Width / 2 - 16) - (this.Width / 2),
            y: 40,
            width: this.Width,
            height: this.Height);

            _ = ProductBackground.FadeTo(0, animationSpeed / 2);
            _ = NameLabel.FadeTo(0, animationSpeed / 2);
            _ = PriceLabel.FadeTo(0, animationSpeed / 2);
            _ = FavouritesButton.FadeTo(0, animationSpeed / 2);
            _ = BasketButton.FadeTo(0, animationSpeed / 2);

            _ = ProductImage.TranslateTo(0, ProductImage.TranslationY, animationSpeed);
            await this.LayoutTo(destRect, animationSpeed, Easing.SinInOut);

            
            _ = ProductImage.TranslateTo(-15, 200, animationSpeed);
            _ = ProductImage.ScaleTo(1.8, animationSpeed - 100);
            Rectangle expandedBounds = bounds.Inflate(50, 50);
            await this.LayoutTo(expandedBounds, animationSpeed, Easing.SinInOut);
            AbsoluteLayout.SetLayoutBounds(this, expandedBounds);
        }

        private void TapProductGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            EventHandler handler = ProductClicked;
            handler?.Invoke(this, new EventArgs());
        }

        private void TapProductGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            EventHandler handler = ProductsTwoClicked;
            handler?.Invoke(this, new EventArgs());
        }

        private void TapProductGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            EventHandler handler = ProductsThreeClicked;
            handler?.Invoke(this, new EventArgs());
        }

        private void TapAddToBasketGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            EventHandler handler = AddToCartClicked;
            handler?.Invoke(this, new EventArgs());
        }
    }
}