using Android.App;
using Android.Widget;
using Android.OS;

namespace SNOW.SHOP.MOBILE.Android1
{
    [Activity(Label = "SNOW.SHOP.MOBILE.Android1", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
        }
    }
}

