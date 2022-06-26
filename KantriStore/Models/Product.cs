using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace KantriStore.Models
{
    public class Product : ObservableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public bool IsFeatured { get; set; }
        public string Category { get; set; }

        /*public override bool Equals(object obj)
        {
            ProductViewModel products = obj as ProductViewModel;
            return this.Id == products.Id;
        }*/

    }

}
