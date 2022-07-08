using System;
using System.Collections.Generic;
using System.Text;

namespace KantriStore.Models
{
    public class ShopingCartItem : ICloneable
    {
        public Product ProductItem { get; set; }

        public int Count { get; set; }

        public decimal Total
        {
            get { return ProductItem.Price * Count; }
            set { }
        }

        public ShopingCartItem()
        {

        }

        public ShopingCartItem (int count, decimal total, Product product)
        {
            Count = count;
            Total = total;
            ProductItem = product;
        }

        public object Clone() => new ShopingCartItem(Count, Total, new Product(ProductItem.Id, ProductItem.Name, ProductItem.ImageUrl, ProductItem.Price, ProductItem.IsFeatured, ProductItem.Category));

    }
}
