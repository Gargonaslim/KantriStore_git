using System;
using System.Collections.Generic;
using System.Text;

namespace KantriStore.Models
{
    public class ShopingCartItem
    {
        public Product ProductItem { get; set; }

        public int Count { get; set; }

        public decimal Total
        {
            get { return ProductItem.Price * Count; }
        }

    }
}
