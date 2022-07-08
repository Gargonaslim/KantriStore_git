using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace KantriStore.Models
{
    public class BasketViewModel : ObservableObject
    {
        private decimal totalAllItems;

        public IList<ShopingCartItem> Items { get; set; }

        public decimal TotalAllItems
        {
            get => totalAllItems;
            set => totalAllItems = value;
        }


        public BasketViewModel()
        {
            Items = new ObservableRangeCollection<ShopingCartItem>();
        }


        private void UpdateTotal()
        {
            TotalAllItems = 0;

            foreach (var item in Items)
            {
                    TotalAllItems += item.Total;
            }
        }

        private ShopingCartItem FindItem(Product itemToFind)
        {
            foreach (var item in Items)
            {

                if (item is ShopingCartItem productItem)
                {
                    if (productItem.ProductItem.Name == itemToFind.Name) 
                        return productItem;
                }
            }
            return null;
        }

        public void IncrementOrder(Product item)
        {

            var foundItem = FindItem(item);

            if (foundItem != null)
            {
                foundItem.Count++;
            }
            else
            {

                var cartItem = new ShopingCartItem()
                {
                    ProductItem = item,
                    Count = 1,
                };
                Items.Insert(0, cartItem);
            }

            UpdateTotal();
        }

        public void RemoveItem(ShopingCartItem item)
        {
            Items.Remove(item);
            UpdateTotal();
        }

    }
}
