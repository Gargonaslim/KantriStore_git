using KantriStore.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;
using MvvmHelpers;
using KantriStore.Services;
using System;

namespace KantriStore.ViewModels
{
    public class ApplicationViewModel : BaseViewModel
    {
        public bool initialized = false;
        DataStoreWeb dataStoreWeb = new DataStoreWeb();

        private Product _seelectedProduct;
        private Product _previousSeelectedProduct;

        public Product SeelectedProduct
        {
            get { return _seelectedProduct; }
            set { SetProperty(ref _seelectedProduct, value);}
        }

        public Product PreviousSeelectedProduct
        {
            get { return _previousSeelectedProduct; }
            set { _previousSeelectedProduct = value; }
        }

        public BasketViewModel Basket { get; set; }

        public IList<Product> AllProducts { get; set; }
        public IList<Product> NewProducts { get; set; }
        public IList<Product> SaleProducts { get; set; }
        public IList<Product> SpecifiedProducts { get; set; }
        public IList<Product> HuntFishProducts { get; set; }

        public IList<Auth> Auths { get; set; }

        public ApplicationViewModel()
        {
            AllProducts = new ObservableRangeCollection<Product>();
            NewProducts = new ObservableRangeCollection<Product>();
            SaleProducts = new ObservableRangeCollection<Product>();
            SpecifiedProducts = new ObservableRangeCollection<Product>();
            HuntFishProducts = new ObservableRangeCollection<Product>();
            Basket = new BasketViewModel();
            Auths = new ObservableRangeCollection<Auth>();
            PreviousSeelectedProduct = new Product
            {
                Id = 0,
                Name = "Жилет Phoenix (тк. Taslan Membrane)",
                ImageUrl = "https://habrastorage.org/webt/fw/pg/tm/fwpgtmhqv-8kwju8im2izwt5eos.png",
                Category = "Спецодежда",
                Price = 1360,
                IsFeatured = false,
            };
        }

        public async Task GetProducts(string url, IList<Product> listProducts)
        {
            if (initialized == true) return;
            IEnumerable<Product> products = await dataStoreWeb.Get(url);

            while (listProducts.Any())
                listProducts.RemoveAt(listProducts.Count - 1);

            foreach (Product f in products)
                listProducts.Add(f);
            IsBusy = false;

            
        }

        public async Task GetAuths(string url, IList<Auth> auths)
        {
            if (initialized == true) return;
            IEnumerable<Auth> auth = await dataStoreWeb.GetAuth(url);

            while (auths.Any())
                auths.RemoveAt(auths.Count - 1);

            foreach (Auth f in auth)
                auths.Add(f);
            IsBusy = false;


        }

    }
}
