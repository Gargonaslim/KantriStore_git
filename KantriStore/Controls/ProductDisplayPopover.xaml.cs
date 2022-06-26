using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KantriStore.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KantriStore.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDisplayPopover : ContentView
    {
        public ProductDisplayPopover()
        {
            InitializeComponent();
        }


        internal async Task Expand()
        {
            this.Opacity = 1;
            ProductPopoverGrid.Opacity = 0;
            BackgroundPanel.TranslationY = BackgroundPanel.Height;
            _ = BackgroundPanel.TranslateTo(0, 0, 200);
            _ = ProductPopoverGrid.FadeTo(1, 250);
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            ((HomePage)this.GetParentPage()).HidePopover();
        }

    }
}