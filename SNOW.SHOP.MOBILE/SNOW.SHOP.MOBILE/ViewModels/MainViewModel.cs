using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SNOW.SHOP.MOBILE.ViewModels.Base;
using SNOW.SHOP.MOBILE.Models.Navigation;
using Xamarin.Forms;
using System.Windows.Input;
using SNOW.SHOP.MOBILE.Services.Navigation;

namespace SNOW.SHOP.MOBILE.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand SettingsCommand => new Command(async () => await SettingsAsync());

        public override Task InitializeAsync(object navigationData)
        {
            IsBusy = true;

            if (navigationData is TabParameter)
            {
                // Change selected application tab
                var tabIndex = ((TabParameter)navigationData).TabIndex;
                //MessagingCenter.Send(this, MessageKeys.ChangeTab, tabIndex);
            }

            return base.InitializeAsync(navigationData);
        }

        private async Task SettingsAsync()
        {
            //await NavigationService.NavigateToAsync<SettingsViewModel>();
        }
    }
}