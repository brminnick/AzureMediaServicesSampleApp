using Android.OS;
using Android.App;
using Android.Content.PM;

namespace AzureMediaServicesSampleApp.Droid
{
    [Activity(Label = "AzureMediaServicesSampleApp.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            MediaManager.CrossMediaManager.Current.Init();

            LoadApplication(new App());
        }
    }
}
