using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SNOW.SHOP.MOBILE.ViewModels.Base;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using SNOW.SHOP.MOBILE.Models.Catalog;
using SNOW.SHOP.MOBILE.Services.Catalog;
using System.Windows.Input;

namespace SNOW.SHOP.MOBILE.ViewModels
{
    public class CatalogViewModel : ViewModelBase
    {
        private ObservableCollection<CatalogProduct> _products;
        private ObservableCollection<CatalogBrand> _brands;
        private CatalogBrand _brand;
        private ObservableCollection<CatalogCategory> _types;
        private CatalogCategory _type;
        private ICatalogService _productsService;

        public CatalogViewModel(ICatalogService productsService)
        {
            _productsService = productsService;
        }

        public ObservableCollection<CatalogProduct> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                RaisePropertyChanged(() => Products);
            }
        }

        public ObservableCollection<CatalogBrand> Brands
        {
            get { return _brands; }
            set
            {
                _brands = value;
                RaisePropertyChanged(() => Brands);
            }
        }

        public CatalogBrand Brand
        {
            get { return _brand; }
            set
            {
                _brand = value;
                RaisePropertyChanged(() => Brand);
                RaisePropertyChanged(() => IsFilter);
            }
        }

        public ObservableCollection<CatalogCategory> Types
        {
            get { return _types; }
            set
            {
                _types = value;
                RaisePropertyChanged(() => Types);
            }
        }

        public CatalogCategory Type
        {
            get { return _type; }
            set
            {
                _type = value;
                RaisePropertyChanged(() => Type);
                RaisePropertyChanged(() => IsFilter);
            }
        }

        public bool IsFilter { get { return Brand != null || Type != null; } }

        public ICommand AddCatalogProductCommand => new Command<CatalogProduct>(AddCatalogProduct);

        public ICommand FilterCommand => new Command(async () => await FilterAsync());

        public ICommand ClearFilterCommand => new Command(async () => await ClearFilterAsync());

        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;

            // Get Catalog, Brands and Types
            Products = await _productsService.GetCatalogAsync();
            Brands = await _productsService.GetCatalogBrandAsync();
            Types = await _productsService.GetCatalogCategoryAsync();

            IsBusy = false;
        }

        private void AddCatalogProduct(CatalogProduct CatalogProduct)
        {
            // Add new item to Basket
            //MessagingCenter.Send(this, MessageKeys.AddProduct, CatalogProduct);
        }

        private async Task FilterAsync()
        {
            if (Brand == null || Type == null)
            {
                return;
            }

            IsBusy = true;

            // Filter catalog products
           // MessagingCenter.Send(this, MessageKeys.Filter);
            Products = await _productsService.FilterAsync(Brand.Id, Type.Id);

            IsBusy = false;
        }

        private async Task ClearFilterAsync()
        {
            IsBusy = true;

            Brand = null;
            Type = null;
            Products = await _productsService.GetCatalogAsync();

            IsBusy = false;
        }
    }
}
