using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SNOW.SHOP.MOBILE.Extensions;
using SNOW.SHOP.MOBILE.Models.Catalog;
using System.Collections.ObjectModel;
using Xamarin.Forms;


namespace SNOW.SHOP.MOBILE.Services.Catalog
{
    public class CatalogMockService : ICatalogService
    {
        private ObservableCollection<CatalogBrand> MockCatalogBrand = new ObservableCollection<CatalogBrand>
        {
            new CatalogBrand { Id = 1, Brand = "Azure" },
            new CatalogBrand { Id = 2, Brand = "Visual Studio" }
        };

        private ObservableCollection<CatalogCategory> MockCatalogCategory = new ObservableCollection<CatalogCategory>
        {
            new CatalogCategory { Id = 1, Category = "Mug" },
            new CatalogCategory { Id = 2, Category = "T-Shirt" }
        };

        private ObservableCollection<CatalogProduct> MockCatalog = new ObservableCollection<CatalogProduct>
        {
            new CatalogProduct { Id = "1", PictureUri = Device.RuntimePlatform != Device.Windows ? "fake_product_01.png" : "Assets/fake_product_01.png", Name = ".NET Bot Blue Sweatshirt (M)", Price = 19.50M, CatalogBrandId = 2, CatalogBrand = "Visual Studio", CatalogCategoryId = 2, CatalogCategory = "T-Shirt" },
            new CatalogProduct { Id = "2", PictureUri = Device.RuntimePlatform != Device.Windows ? "fake_product_02.png" : "Assets/fake_product_02.png", Name = ".NET Bot Purple Sweatshirt (M)", Price = 19.50M, CatalogBrandId = 2, CatalogBrand = "Visual Studio", CatalogCategoryId = 2, CatalogCategory = "T-Shirt" },
            new CatalogProduct { Id = "3", PictureUri = Device.RuntimePlatform != Device.Windows ? "fake_product_03.png" : "Assets/fake_product_03.png", Name = ".NET Bot Black Sweatshirt (M)", Price = 19.95M, CatalogBrandId = 2, CatalogBrand = "Visual Studio", CatalogCategoryId = 2, CatalogCategory = "T-Shirt" },
            new CatalogProduct { Id = "4", PictureUri = Device.RuntimePlatform != Device.Windows ? "fake_product_04.png" : "Assets/fake_product_04.png", Name = ".NET Black Cupt", Price = 17.00M, CatalogBrandId = 2, CatalogBrand = "Visual Studio", CatalogCategoryId = 1, CatalogCategory = "Mug" },
            new CatalogProduct { Id = "5", PictureUri = Device.RuntimePlatform != Device.Windows ? "fake_product_05.png" : "Assets/fake_product_05.png", Name = "Azure Black Sweatshirt (M)", Price = 19.50M, CatalogBrandId = 1, CatalogBrand = "Azure", CatalogCategoryId = 2, CatalogCategory = "T-Shirt" }
        };

        public async Task<ObservableCollection<CatalogProduct>> GetCatalogAsync()
        {
            await Task.Delay(500);

            return MockCatalog;
        }

        public async Task<ObservableCollection<CatalogProduct>> FilterAsync(int catalogBrandId, int CatalogCategoryId)
        {
            await Task.Delay(500);

            return MockCatalog
                .Where(c => c.CatalogBrandId == catalogBrandId &&
                c.CatalogCategoryId == CatalogCategoryId)
                .ToObservableCollection();
        }

        public async Task<ObservableCollection<CatalogBrand>> GetCatalogBrandAsync()
        {
            await Task.Delay(500);

            return MockCatalogBrand;
        }

        public async Task<ObservableCollection<CatalogCategory>> GetCatalogCategoryAsync()
        {
            await Task.Delay(500);

            return MockCatalogCategory;
        }
    }
}
