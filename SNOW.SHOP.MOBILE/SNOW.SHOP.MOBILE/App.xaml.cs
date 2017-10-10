using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Globalization;
using SNOW.SHOP.MOBILE.Helpers;
using SNOW.SHOP.MOBILE.Services;
using SNOW.SHOP.MOBILE.ViewModels.Base;
using System.Threading.Tasks;
using SNOW.SHOP.MOBILE.Services.Navigation;
using SNOW.SHOP.MOBILE.Views;

//using SNOW.SHOP.MOBILE.Models.Location;
//using SNOW.SHOP.MOBILE.Services.Location;
//using Plugin.Geolocator;
/*
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SNOW.SHOP.MOBILE
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
*/

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SNOW.SHOP.MOBILE
{
    public partial class App : Application
    {
        public bool UseMockServices { get; set; }

        public App()
        {
            InitializeComponent();
           
            //MainPage = new MainPage();
            //ViewModelLocator.RegisterDependencies(true);
            //MainPage = new CatalogView();
            
            InitApp();

            if (Device.RuntimePlatform == Device.WinRT)
            {
                InitNavigation();
            }
            
        }

        private void InitApp()
        {
            UseMockServices = true;// Settings.UseMocks;
            ViewModelLocator.RegisterDependencies(UseMockServices);
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
           
        }

        //protected override void OnStart()
        protected override async void OnStart()
        {
            
            base.OnStart();

            if (Device.RuntimePlatform != Device.WinRT)
            {
                await InitNavigation();
            }
            
            /*
            if (Settings.AllowGpsLocation && !Settings.UseFakeLocation)
            {
                await GetGpsLocation();
            }

            if (!Settings.UseMocks && !string.IsNullOrEmpty(Settings.AuthAccessToken))
            {
                await SendCurrentLocation();
            }
            */
            base.OnResume();
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }
        /*
        private async Task GetGpsLocation()
        {
            var locator = CrossGeolocator.Current;

            if (locator.IsGeolocationEnabled && locator.IsGeolocationAvailable)
            {
                locator.AllowsBackgroundUpdates = true;
                locator.DesiredAccuracy = 50;

                var position = await locator.GetPositionAsync();

                Settings.Latitude = position.Latitude.ToString();
                Settings.Longitude = position.Longitude.ToString();
            }
            else
            {
                Settings.AllowGpsLocation = false;
            }
        }
        */
        /*
        private async Task SendCurrentLocation()
        {
            var location = new Location
            {
                Latitude = double.Parse(Settings.Latitude, CultureInfo.InvariantCulture),
                Longitude = double.Parse(Settings.Longitude, CultureInfo.InvariantCulture)
            };

            var locationService = ViewModelLocator.Resolve<ILocationService>();
            await locationService.UpdateUserLocation(location,
                Settings.AuthAccessToken);
        }
        */
    }
}