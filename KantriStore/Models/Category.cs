using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace KantriStore.Models
{
    public class Category : ObservableObject
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }
        public string ImageUrl { get; set; }

    }
}
