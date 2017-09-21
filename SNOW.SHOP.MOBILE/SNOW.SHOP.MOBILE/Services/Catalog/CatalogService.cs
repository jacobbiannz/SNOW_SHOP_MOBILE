using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using SNOW.SHOP.MOBILE.Models.Catalog;
using SNOW.SHOP.MOBILE.Services.RequestProvider;
using SNOW.SHOP.MOBILE.Extensions;

namespace SNOW.SHOP.MOBILE.Services.Catalog
{
    public class CatalogService : ICatalogService
    {
        private readonly IRequestProvider _requestProvider;

        public CatalogService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<ObservableCollection<CatalogProduct>> FilterAsync(int catalogBrandId, int CatalogCategoryId)
        {
            UriBuilder builder = new UriBuilder(GlobalSetting.Instance.CatalogEndpoint);

            builder.Path = string.Format("api/product/products/category/{0}/brand/{1}", CatalogCategoryId, catalogBrandId);

            string uri = builder.ToString();

            CatalogRoot catalog =
                    await _requestProvider.GetAsync<CatalogRoot>(uri);

            if (catalog?.Data != null)
                return catalog?.Data.ToObservableCollection();
            else
                return new ObservableCollection<CatalogProduct>();
        }

        public async Task<ObservableCollection<CatalogProduct>> GetCatalogAsync()
        {
            UriBuilder builder = new UriBuilder(GlobalSetting.Instance.CatalogEndpoint);

            builder.Path = "api/product/products";

            string uri = builder.ToString();

            CatalogRoot catalog =
                await _requestProvider.GetAsync<CatalogRoot>(uri);

            if (catalog?.Data != null)
            {
                //ServicesHelper.FixCatalogProductPictureUri(catalog?.Data);

                return catalog?.Data.ToObservableCollection();
            }
            else
                return new ObservableCollection<CatalogProduct>();
        }

        
        public async Task<ObservableCollection<CatalogBrand>> GetCatalogBrandAsync()
        {
            UriBuilder builder = new UriBuilder(GlobalSetting.Instance.CatalogEndpoint);

            builder.Path = "api/brand/brands";

            string uri = builder.ToString();

            IEnumerable<CatalogBrand> brands =
                   await _requestProvider.GetAsync<IEnumerable<CatalogBrand>>(uri);

            if (brands != null)
                return brands?.ToObservableCollection();
            else
                return new ObservableCollection<CatalogBrand>();
        }
        

        public async Task<ObservableCollection<CatalogCategory>> GetCatalogCategoryAsync()
        {
            UriBuilder builder = new UriBuilder(GlobalSetting.Instance.CatalogEndpoint);

            builder.Path = "api/category/categorys";

            string uri = builder.ToString();

            IEnumerable<CatalogCategory> categories =
                    await _requestProvider.GetAsync<IEnumerable<CatalogCategory>>(uri);

            if (categories != null)
                return categories.ToObservableCollection();
            else
                return new ObservableCollection<CatalogCategory>();
        }
    }
}
