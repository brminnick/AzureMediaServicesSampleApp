using Xamarin.Forms;

using Plugin.MediaManager;

using AzureMediaServicesSampleApp.Shared;

namespace AzureMediaServicesSampleApp
{
    public class App : Application
    {
        public App() => MainPage = new NavigationPage(new VideoSelectionPage());

        protected override void OnStart()
        {
            base.OnStart();

            CrossMediaManager.Current.RequestHeaders.Add("Authorization", MediaConstants.EncryptedVideoBearerToken);
        }
    }
}
