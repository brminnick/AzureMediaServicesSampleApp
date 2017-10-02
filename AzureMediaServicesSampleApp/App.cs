using Xamarin.Forms;

using Plugin.MediaManager;

using AzureMediaServicesSampleApp.Shared;

namespace AzureMediaServicesSampleApp
{
    public class App : Application
    {
        public App()
        {
            CrossMediaManager.Current.RequestHeaders.Add(MediaConstants.EncryptedVideoHeaderKey, MediaConstants.EncryptedVideoHeaderToken);

            MainPage = new NavigationPage(new VideoSelectionPage());
        }
    }
}
