using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SlideOverKit;

using SNOW.SHOP.MOBILE.ViewModels.Base;
using SNOW.SHOP.MOBILE.ViewModels;

namespace SNOW.SHOP.MOBILE.Views
{
    public partial class CatalogView : ContentPage, IMenuContainerPage
    {
        public Action HideMenuAction
        {
            get;
            set;
        }

        public Action ShowMenuAction
        {
            get;
            set;
        }

        public SlideMenuView SlideMenu
        {
            get;
            set;
        }

        private FiltersView _filterView = new FiltersView();

        public CatalogView()
        {
            InitializeComponent();
           
            this.SlideMenu = _filterView;
          
            MessagingCenter.Subscribe<CatalogViewModel>(this, MessageKeys.Filter, (sender) =>
            {
                Filter();
            });
            
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            _filterView.BindingContext = BindingContext;
        }

        private void OnFilterChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void Filter()
        {

            if (SlideMenu.IsShown)
            {
                HideMenuAction?.Invoke();
            }
            else
            {
                ShowMenuAction?.Invoke();
            }
        }
            
    }
}