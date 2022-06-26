using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace KantriStore.Models
{
    public class Auth : ObservableObject
    {
        public int Id_user { get; set; }
        public string login { get; set; }
        public decimal Password { get; set; }
    }
}
