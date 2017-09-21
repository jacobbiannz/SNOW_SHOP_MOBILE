using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SNOW.SHOP.MOBILE.Models.Catalog;
using System.Collections.ObjectModel;

namespace SNOW.SHOP.MOBILE.Services.Catalog
{
    public interface ICatalogService
    {
        Task<ObservableCollection<CatalogBrand>> GetCatalogBrandAsync();
        Task<ObservableCollection<CatalogProduct>> FilterAsync(int catalogBrandId, int catalogTypeId);
        Task<ObservableCollection<CatalogCategory>> GetCatalogCategoryAsync();
        Task<ObservableCollection<CatalogProduct>> GetCatalogAsync();
    }
}
