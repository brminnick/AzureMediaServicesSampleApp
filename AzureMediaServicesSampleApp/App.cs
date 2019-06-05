using MediaManager;

using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace AzureMediaServicesSampleApp
{
    public class App : Xamarin.Forms.Application
    {
        public App()
        {
            CrossMediaManager.Current.RequestHeaders.Add(MediaConstants.EncryptedVideoHeaderKey, MediaConstants.EncryptedVideoHeaderToken);

            var mainPage = new Xamarin.Forms.NavigationPage(new VideoSelectionPage());
            mainPage.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            MainPage = mainPage;
        }
    }
}
